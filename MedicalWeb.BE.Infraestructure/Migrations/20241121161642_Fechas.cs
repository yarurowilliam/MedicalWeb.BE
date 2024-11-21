using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Fechas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            // Crear nuevamente la tabla HorarioMedico sin MesID y YearsID
            migrationBuilder.CreateTable(
                name: "HorarioMedico",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraID = table.Column<int>(type: "int", nullable: false),
                    DiaID = table.Column<int>(type: "int", nullable: false),
                    EstadoHorarioID = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdentificacionCliente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false)
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
                });

            // Crear índices
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la tabla HorarioMedico
            migrationBuilder.DropTable(
                name: "HorarioMedico",
                schema: "dbo");

            // Restaurar la tabla con las columnas MesID y YearsID si se requiere
            migrationBuilder.CreateTable(
                name: "HorarioMedico",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraID = table.Column<int>(type: "int", nullable: false),
                    DiaID = table.Column<int>(type: "int", nullable: false),
                    EstadoHorarioID = table.Column<int>(type: "int", nullable: false),
                    MesID = table.Column<int>(type: "int", nullable: false),
                    YearsID = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdentificacionCliente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioMedico_Mes_MesID",
                        column: x => x.MesID,
                        principalSchema: "dbo",
                        principalTable: "Mes",
                        principalColumn: "MesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioMedico_Years_YearsID",
                        column: x => x.YearsID,
                        principalSchema: "dbo",
                        principalTable: "Years",
                        principalColumn: "YearsID",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
