using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListReport1._3.Migrations
{
    public partial class InitPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Trade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HblNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MblNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Ata = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PolPod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Shipper = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Vessel = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Commodity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Teus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Volume = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Measurement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Flag = table.Column<int>(type: "integer", nullable: true),
                    AgentName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AgentInvoiceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AgentAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    AgentDateIssued = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AgentDatePaid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SlPayable = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SlInvoiceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SlAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    SlDateIssued = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SlDatePaid = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SlNum = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SlNumAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Ewt = table.Column<decimal>(type: "numeric", nullable: true),
                    EwtTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    DmPhp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DmPhpAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    DmUsd = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DmUsdAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Revenue = table.Column<decimal>(type: "numeric", nullable: true),
                    ProfitFrom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ProfitAmount = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TradeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingDetails");

            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
