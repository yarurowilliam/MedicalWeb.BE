using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FKRolEnUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar la columna RolId con valor predeterminado de 2
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                schema: "dbo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 2);

            // Crear el índice para RolId
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                schema: "dbo",
                table: "Usuarios",
                column: "RolId");

            // Crear la clave foránea para RolId
            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                schema: "dbo",
                table: "Usuarios",
                column: "RolId",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la clave foránea, índice y columna RolId
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                schema: "dbo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                schema: "dbo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolId",
                schema: "dbo",
                table: "Usuarios");
        }
    }
}