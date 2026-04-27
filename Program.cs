using ListReport1._3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// 🌐 Render requires binding to this port
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// 🔑 Get DATABASE_URL from Render
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

if (string.IsNullOrEmpty(databaseUrl))
{
    throw new Exception("❌ DATABASE_URL is not set.");
}

// 🔧 Parse DATABASE_URL → Npgsql connection string
var uri = new Uri(databaseUrl);
var userInfo = uri.UserInfo.Split(':');

var connectionString = new NpgsqlConnectionStringBuilder
{
    Host = uri.Host,
    Port = uri.Port > 0 ? uri.Port : 5432, // fallback fix
    Username = userInfo[0],
    Password = userInfo[1],
    Database = uri.AbsolutePath.Trim('/'),
    SslMode = SslMode.Require,
    TrustServerCertificate = true
}.ToString();

// 🗄️ Register DbContexts (PostgreSQL ONLY)
builder.Services.AddDbContext<ShippingDetailsContext>(options =>
    options.UseNpgsql(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));

// 🔐 Identity
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🚀 APPLY MIGRATIONS BEFORE HANDLING REQUESTS
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        Console.WriteLine("🚀 Starting database migrations...");

        var shippingContext = services.GetRequiredService<ShippingDetailsContext>();
        shippingContext.Database.Migrate();
        Console.WriteLine("✅ ShippingDetails migrated");

        var identityContext = services.GetRequiredService<ApplicationDbContext>();
        identityContext.Database.Migrate();
        Console.WriteLine("✅ Identity migrated");

        Console.WriteLine("🎉 All migrations applied successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ MIGRATION FAILED:");
        Console.WriteLine(ex.ToString());
    }
}

// ⚙️ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ⚠️ Keep OFF unless HTTPS is configured properly in Render
// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// 📍 Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ShippingDetails}/{action=Table}/{id?}");

app.MapRazorPages();

app.Run();