using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CancelacionCitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancelacionCita",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UsuarioQueCanceloId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelacionCita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancelacionCita_HorarioMedico_CitaId",
                        column: x => x.CitaId,
                        principalSchema: "dbo",
                        principalTable: "HorarioMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancelacionCita_CitaId",
                schema: "dbo",
                table: "CancelacionCita",
                column: "CitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelacionCita",
                schema: "dbo");
        }
    }
}
