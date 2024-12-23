using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Pacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoDocumento",
                schema: "dbo",
                table: "Medicos",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pacientes",
                type: "NVARCHAR(50)",
                nullable: false, // Cambia esto según si la columna es requerida o no
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)" // Reemplaza esto con el tipo anterior si lo sabes.
            );


            migrationBuilder.AddColumn<decimal>(
            name: "Peso",
            table: "Pacientes",
            type: "decimal(10,2)",
            nullable: false,
            defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Altura",
                table: "Pacientes",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Pacientes",
                schema: "dbo",
                columns: table => new
                {
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TieneAlergias = table.Column<bool>(type: "bit", nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Medicamentos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EnfermedadesCronicas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AntecedentesFamiliares = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    Estado = table.Column<bool>(type: "bit", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Pacientes_TipoDocumento_TipoDocumento",
                        column: x => x.TipoDocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteNumeroDocumento = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicion_Pacientes_NumeroDocumento",
                        column: x => x.NumeroDocumento,
                        principalSchema: "dbo",
                        principalTable: "Pacientes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicion_Pacientes_PacienteNumeroDocumento",
                        column: x => x.PacienteNumeroDocumento,
                        principalSchema: "dbo",
                        principalTable: "Pacientes",
                        principalColumn: "NumeroDocumento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_NumeroDocumento",
                schema: "dbo",
                table: "Medicion",
                column: "NumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_PacienteNumeroDocumento",
                schema: "dbo",
                table: "Medicion",
                column: "PacienteNumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_TipoDocumento",
                schema: "dbo",
                table: "Pacientes",
                column: "TipoDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pacientes",
                schema: "dbo");


            migrationBuilder.AlterColumn<string>(
                name: "TipoDocumento",
                schema: "dbo",
                table: "Medicos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Pacientes");

        }
    }
}
