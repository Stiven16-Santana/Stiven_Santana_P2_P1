using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stiven_Santana_P2_P1.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoColumnaMontoACiudades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "Ciudades",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Ciudades");
        }
    }
}
