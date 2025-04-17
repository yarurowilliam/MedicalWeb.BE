using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla Rol
            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            // Crear índice único en la columna Nombre
            migrationBuilder.CreateIndex(
                name: "IX_Rol_Nombre",
                schema: "dbo",
                table: "Rol",
                column: "Nombre",
                unique: true);

            // Insertar los datos del enum Rol
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "ADMINISTRADOR" },
                    { 2, "MEDICO" },
                    { 3, "PACIENTE" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la tabla Rol
            migrationBuilder.DropTable(
                name: "Rol",
                schema: "dbo");
        }
    }
}