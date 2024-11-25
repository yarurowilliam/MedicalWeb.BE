using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAlertas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoAlerta",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAlerta", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "EstadoAlerta",
                columns: new[] { "Id", "EstadoName" },
                values: new object[,]
                {
                { 1, "ACTIVO" },
                { 2, "RESUELTO" },
                { 3, "OMITIDO" }
                });

            migrationBuilder.CreateTable(
                name: "Alerta",
                schema: "dbo",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EstadoAlertaId = table.Column<int>(type: "int", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_Alerta_EstadoAlerta_EstadoAlertaId",
                        column: x => x.EstadoAlertaId,
                        principalSchema: "dbo",
                        principalTable: "EstadoAlerta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerta_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_EstadoAlertaId",
                schema: "dbo",
                table: "Alerta",
                column: "EstadoAlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_IdUsuario",
                schema: "dbo",
                table: "Alerta",
                column: "IdUsuario",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoAlerta_EstadoName",
                schema: "dbo",
                table: "EstadoAlerta",
                column: "EstadoName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Alerta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EstadoAlerta",
                schema: "dbo");
        }

    }
}
