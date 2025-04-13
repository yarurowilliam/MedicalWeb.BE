using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Reportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoReporte",
                schema: "dbo",
                columns: table => new
                {
                    EstadoReporteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReporte", x => x.EstadoReporteID);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_EstadoReporte_Estado",
                        column: x => x.Estado,
                        principalSchema: "dbo",
                        principalTable: "EstadoReporte",
                        principalColumn: "EstadoReporteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadoReporte_Code",
                schema: "dbo",
                table: "EstadoReporte",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Estado",
                schema: "dbo",
                table: "Reporte",
                column: "Estado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reporte",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EstadoReporte",
                schema: "dbo");
        }
    }
}