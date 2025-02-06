using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class EstadoHorarioMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 1,
                column: "Code",
                value: "PENDIENTE");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 2,
                column: "Code",
                value: "VENCIDA");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 3,
                column: "Code",
                value: "EN CURSO");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "EstadoHorario",
                columns: new[] { "EstadoHorarioID", "Code" },
                values: new object[] { 4, "CANCELADA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 1,
                column: "Code",
                value: "DISPONIBLE");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 2,
                column: "Code",
                value: "OCUPADO");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "EstadoHorario",
                keyColumn: "EstadoHorarioID",
                keyValue: 3,
                column: "Code",
                value: "NO DISPONIBLE");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_RolId",
                schema: "dbo",
                table: "UsuarioRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_UsuarioId",
                schema: "dbo",
                table: "UsuarioRoles",
                column: "UsuarioId");
        }
    }
}
