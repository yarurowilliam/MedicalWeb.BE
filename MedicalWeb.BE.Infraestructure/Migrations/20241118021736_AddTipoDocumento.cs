using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    public partial class AddTipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla 'TipoDocumento' en el esquema 'dbo'
            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            // Crear índice único sobre la columna 'Name'
            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumento_Name",
                schema: "dbo",
                table: "TipoDocumento",
                column: "Name",
                unique: true);

            // Insertar los valores predeterminados definidos en la clase TipoDocumento
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoDocumento",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cedula Ciudadania" },
                    { 2, "Tarjeta de Identidad" },
                    { 3, "Pasaporte" },
                    { 4, "Cedula Extranjeria" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la tabla 'TipoDocumento' en el esquema 'dbo'
            migrationBuilder.DropTable(
                name: "TipoDocumento",
                schema: "dbo");
        }
    }
}
