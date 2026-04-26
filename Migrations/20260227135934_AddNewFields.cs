using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListReport1._3.Migrations
{
    public partial class AddNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentAmount",
                table: "ShippingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AgentDateIssued",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentDatePaid",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentInvoiceNo",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentName",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlAmount",
                table: "ShippingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SlDateIssued",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlDatePaid",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlInvoiceNo",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlPayable",
                table: "ShippingDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentAmount",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "AgentDateIssued",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "AgentDatePaid",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "AgentInvoiceNo",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "AgentName",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlAmount",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlDateIssued",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlDatePaid",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlInvoiceNo",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "SlPayable",
                table: "ShippingDetails");
        }
    }
}
