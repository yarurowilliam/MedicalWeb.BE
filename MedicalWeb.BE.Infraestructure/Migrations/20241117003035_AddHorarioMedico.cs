using Microsoft.EntityFrameworkCore.Migrations;
using System.Xml.Serialization;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHorarioMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dias",
                schema: "dbo",
                columns: table => new
                {
                    DiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.DiaID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoHorario",
                schema: "dbo",
                columns: table => new
                {
                    EstadoHorarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoHorario", x => x.EstadoHorarioID);
                });

            migrationBuilder.CreateTable(
                name: "HorasMedicas",
                schema: "dbo",
                columns: table => new
                {
                    HoraMedicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasMedicas", x => x.HoraMedicaID);
                });

            migrationBuilder.CreateTable(
                name: "HorarioMedico",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaID = table.Column<int>(type: "int", nullable: false),
                    HoraID = table.Column<int>(type: "int", nullable: false),
                    EstadoHorarioID = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdentificacionCliente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioMedico_Dias_DiaID",
                        column: x => x.DiaID,
                        principalSchema: "dbo",
                        principalTable: "Dias",
                        principalColumn: "DiaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioMedico_EstadoHorario_EstadoHorarioID",
                        column: x => x.EstadoHorarioID,
                        principalSchema: "dbo",
                        principalTable: "EstadoHorario",
                        principalColumn: "EstadoHorarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioMedico_HorasMedicas_HoraID",
                        column: x => x.HoraID,
                        principalSchema: "dbo",
                        principalTable: "HorasMedicas",
                        principalColumn: "HoraMedicaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioMedico_Medicos_NumeroDocumento",
                        column: x => x.NumeroDocumento,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "EstadoHorario",
                columns: new[] { "EstadoHorarioID", "Code" },
                values: new object[,]
                {
                    { 1, "DISPONIBLE" },
                    { 2, "OCUPADO" },
                    { 3, "NO DISPONIBLE" }
                });


            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Dias",
                columns: new [] { "DiaID", "Code" },
                values: new object[,]
                {
                    {1, "LUNES" },
                    {2, "MARTES"},
                    {3, "MIÉRCOLES"},
                    {4, "JUEVES"},
                    {5, "VIERNES"},
                    {6, "SÁBADO"},
                    {7, "DOMINGO"}
                }
                );


            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HorasMedicas",
                columns: new[] { "HoraMedicaID", "Code" },
                values: new object[,]
                {
                    { 1, "6:00 AM" },
                    { 2, "7:00 AM" },
                    { 3, "8:00 AM" },
                    { 4, "9:00 AM" },
                    { 5, "10:00 AM" },
                    { 6, "11:00 AM" },
                    { 7, "12:00 PM" },
                    { 8, "1:00 PM" },
                    { 9, "2:00 PM" },
                    { 10, "3:00 PM" },
                    { 11, "4:00 PM" },
                    { 12, "5:00 PM" },
                    { 13, "6:00 PM" }
                }
                );

            migrationBuilder.CreateIndex(
                name: "IX_Dias_Code",
                schema: "dbo",
                table: "Dias",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoHorario_Code",
                schema: "dbo",
                table: "EstadoHorario",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioMedico_DiaID",
                schema: "dbo",
                table: "HorarioMedico",
                column: "DiaID");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioMedico_EstadoHorarioID",
                schema: "dbo",
                table: "HorarioMedico",
                column: "EstadoHorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioMedico_HoraID",
                schema: "dbo",
                table: "HorarioMedico",
                column: "HoraID");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioMedico_NumeroDocumento",
                schema: "dbo",
                table: "HorarioMedico",
                column: "NumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_HorasMedicas_Code",
                schema: "dbo",
                table: "HorasMedicas",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioMedico",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Dias",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EstadoHorario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HorasMedicas",
                schema: "dbo");
        }
    }
}
