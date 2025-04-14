using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Incapacidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incapacidad",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumentoPaciente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroDocumentoMedico = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracionDias = table.Column<int>(type: "int", nullable: false),
                    NumeroPrescripcionSustituida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incapacidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Incapacidad_Medicos_NumeroDocumentoMedico",
                        column: x => x.NumeroDocumentoMedico,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento");
                    table.ForeignKey(
                        name: "FK_Incapacidad_Pacientes_NumeroDocumentoPaciente",
                        column: x => x.NumeroDocumentoPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incapacidad_NumeroDocumentoMedico",
                schema: "dbo",
                table: "Incapacidad",
                column: "NumeroDocumentoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Incapacidad_NumeroDocumentoPaciente",
                schema: "dbo",
                table: "Incapacidad",
                column: "NumeroDocumentoPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incapacidad",
                schema: "dbo");
        }
    }
}
