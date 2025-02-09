using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustesTablaHistoriaClinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.AddColumn<string>(
                name: "NombreMedico",
                schema: "dbo",
                table: "HistoriaClinica",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePaciente",
                schema: "dbo",
                table: "HistoriaClinica",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
           

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "NombreMedico",
                schema: "dbo",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "NombrePaciente",
                schema: "dbo",
                table: "HistoriaClinica");

          
        }
    }
}
