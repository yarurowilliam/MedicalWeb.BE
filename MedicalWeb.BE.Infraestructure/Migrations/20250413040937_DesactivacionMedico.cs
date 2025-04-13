using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class DesactivacionMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesactivacionMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesactivacionMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesactivacionMedico_Medicos_NumeroDocumento",
                        column: x => x.NumeroDocumento,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesactivacionMedico_NumeroDocumento",
                table: "DesactivacionMedico",
                column: "NumeroDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesactivacionMedico");
        }
    }
}
