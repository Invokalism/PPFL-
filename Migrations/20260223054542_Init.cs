using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListReport1._3.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HblNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MblNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ata = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PolPod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Shipper = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Vessel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Commodity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Teus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDetails", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingDetails");
        }
    }
}
