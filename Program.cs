using ListReport1._3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Render port
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// ✅ Get DATABASE_URL from Render
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

if (string.IsNullOrEmpty(databaseUrl))
{
    throw new Exception("DATABASE_URL is not set.");
}

// ✅ Parse DATABASE_URL safely
var uri = new Uri(databaseUrl);
var userInfo = uri.UserInfo.Split(':');

var connectionString = new NpgsqlConnectionStringBuilder
{
    Host = uri.Host,
    Port = uri.Port > 0 ? uri.Port : 5432,
    Username = userInfo[0],
    Password = userInfo[1],
    Database = uri.AbsolutePath.Trim('/'),
    SslMode = SslMode.Require,
    TrustServerCertificate = true
}.ToString();

// 👉 Register DbContexts (PostgreSQL only)
builder.Services.AddDbContext<ShippingDetailsContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Identity
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ⚠️ IMPORTANT: Keep this OFF on Render unless configured properly
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ShippingDetails}/{action=Table}/{id?}");

app.MapRazorPages();

// ✅ AUTO APPLY MIGRATIONS (VERY IMPORTANT)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ShippingDetailsContext>();
        context.Database.Migrate();

        var identityContext = services.GetRequiredService<ApplicationDbContext>();
        identityContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Migration error: " + ex.Message);
    }
}

app.Run();