using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicoEspecialidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoEspecialidad",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoNumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalSchema: "dbo",
                        principalTable: "Especialidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Medicos_MedicoNumeroDocumento",
                        column: x => x.MedicoNumeroDocumento,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidad_EspecialidadId",
                schema: "dbo",
                table: "MedicoEspecialidad",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidad_MedicoNumeroDocumento",
                schema: "dbo",
                table: "MedicoEspecialidad",
                column: "MedicoNumeroDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoEspecialidad",
                schema: "dbo");
        }
    }
}
