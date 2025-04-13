using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RecetasMedicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recetas",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumentoPaciente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroDocumentoMedico = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recetas_Medicos_NumeroDocumentoMedico",
                        column: x => x.NumeroDocumentoMedico,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento");
                    table.ForeignKey(
                        name: "FK_Recetas_Pacientes_NumeroDocumentoPaciente",
                        column: x => x.NumeroDocumentoPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentoRecetados",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaID = table.Column<int>(type: "int", nullable: false),
                    NombreMedicamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Concentracion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FormaFarmaceutica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadRecetada = table.Column<int>(type: "int", nullable: false),
                    InstruccionesUso = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoRecetados", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicamentoRecetados_Recetas_RecetaID",
                        column: x => x.RecetaID,
                        principalSchema: "dbo",
                        principalTable: "Recetas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoRecetados_RecetaID",
                schema: "dbo",
                table: "MedicamentoRecetados",
                column: "RecetaID");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_NumeroDocumentoMedico",
                schema: "dbo",
                table: "Recetas",
                column: "NumeroDocumentoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_NumeroDocumentoPaciente",
                schema: "dbo",
                table: "Recetas",
                column: "NumeroDocumentoPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicamentoRecetados",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Recetas",
                schema: "dbo");
        }
    }
}
