using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CampoNombreReportes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                schema: "dbo",
                table: "Reporte",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                schema: "dbo",
                table: "Reporte");
        }
    }
}
