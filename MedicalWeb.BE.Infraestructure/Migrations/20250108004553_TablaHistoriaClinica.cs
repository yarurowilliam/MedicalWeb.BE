using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class TablaHistoriaClinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriaClinica",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumentoPaciente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroDocumentoMedico = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MedicamentosActuales = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AntecedentesFamiliares = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AntecedentesPersonales = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sintomas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ObservacionesMedicas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiagnosticoPrincipal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PlanTratamiento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MedicamentosRecetados = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Dosis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DuracionTratamiento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EstadoActivo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Medicos_NumeroDocumentoMedico",
                        column: x => x.NumeroDocumentoMedico,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Pacientes_NumeroDocumentoPaciente",
                        column: x => x.NumeroDocumentoPaciente,
                        principalSchema: "dbo",
                        principalTable: "Pacientes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_NumeroDocumentoMedico",
                schema: "dbo",
                table: "HistoriaClinica",
                column: "NumeroDocumentoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_NumeroDocumentoPaciente",
                schema: "dbo",
                table: "HistoriaClinica",
                column: "NumeroDocumentoPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriaClinica",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Altura",
                schema: "dbo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Peso",
                schema: "dbo",
                table: "Pacientes");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                schema: "dbo",
                table: "Pacientes",
                type: "bit",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }
    }
}
