using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stiven_Santana_P2_P1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asignatura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCiudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EncuestasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCiudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCiudades_Ciudades_EncuestasId",
                        column: x => x.EncuestasId,
                        principalTable: "Ciudades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCiudades_EncuestasId",
                table: "DetalleCiudades",
                column: "EncuestasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCiudades");

            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}
