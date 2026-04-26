using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListReport1._3.Migrations
{
    public partial class AddNewFieldToShippingDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DmPhp",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DmPhpAmount",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DmUsd",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DmUsdAmount",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ewt",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EwtTotal",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfitAmount",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfitFrom",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Revenue",
                table: "ShippingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlNum",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlNumAmount",
                table: "ShippingDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DmPhp",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "DmPhpAmount",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "DmUsd",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "DmUsdAmount",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "Ewt",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "EwtTotal",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "ProfitAmount",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "ProfitFrom",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlNum",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlNumAmount",
                table: "ShippingDetails");
        }
    }
}
