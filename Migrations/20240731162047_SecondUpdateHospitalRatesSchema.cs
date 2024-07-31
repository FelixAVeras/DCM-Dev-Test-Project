using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimProcessing.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdateHospitalRatesSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalRates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalRates",
                table: "HospitalRates",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalRates",
                table: "HospitalRates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalRates");
        }
    }
}
