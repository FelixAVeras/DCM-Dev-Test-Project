using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimProcessing.Migrations
{
    /// <inheritdoc />
    public partial class SecondInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    NPI = table.Column<int>(type: "INTEGER", nullable: false),
                    Month = table.Column<string>(type: "TEXT", nullable: false),
                    NpiMonth = table.Column<string>(type: "TEXT", nullable: false),
                    IpRate = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderName = table.Column<string>(type: "TEXT", nullable: false),
                    HospitalPhysicalCity = table.Column<string>(type: "TEXT", nullable: false),
                    HospitalPhysicalStreetAddress = table.Column<string>(type: "TEXT", nullable: false),
                    HospitalClass = table.Column<string>(type: "TEXT", nullable: false),
                    SDA = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliverySDA = table.Column<decimal>(type: "TEXT", nullable: false),
                    PPR_PPC = table.Column<decimal>(type: "TEXT", nullable: false),
                    Contract = table.Column<int>(type: "INTEGER", nullable: false),
                    HundredPercent = table.Column<int>(type: "INTEGER", nullable: false),
                    HHSC_Publish_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CHIRP_Rate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalRates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalRates");
        }
    }
}
