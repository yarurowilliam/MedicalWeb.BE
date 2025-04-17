using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CancelacionCitas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumDocumentoPaciente",
                schema: "dbo",
                table: "CancelacionCita",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionCita_NumDocumentoPaciente",
                schema: "dbo",
                table: "CancelacionCita",
                column: "NumDocumentoPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_CancelacionCita_Pacientes_NumDocumentoPaciente",
                schema: "dbo",
                table: "CancelacionCita",
                column: "NumDocumentoPaciente",
                principalTable: "Pacientes",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancelacionCita_Pacientes_NumDocumentoPaciente",
                schema: "dbo",
                table: "CancelacionCita");

            migrationBuilder.DropIndex(
                name: "IX_CancelacionCita_NumDocumentoPaciente",
                schema: "dbo",
                table: "CancelacionCita");

            migrationBuilder.DropColumn(
                name: "NumDocumentoPaciente",
                schema: "dbo",
                table: "CancelacionCita");
        }
    }
}
