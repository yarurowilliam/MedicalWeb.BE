using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 2,
                column: "Code",
                value: "COMPLETADA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 2,
                column: "Code",
                value: "VENCIDA");
        }
    }
}
