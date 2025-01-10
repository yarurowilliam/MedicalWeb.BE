    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ENum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HorasMedicas",
                columns: new[] { "HoraMedicaID", "Code" },
                values: new object[,]
                {
                    { 1, "6:00 AM" },
                    { 2, "6:30 AM" },
                    { 3, "7:00 AM" },
                    { 4, "7:30 AM" },
                    { 5, "8:00 AM" },
                    { 6, "8:30 AM" },
                    { 7, "9:00 AM" },
                    { 8, "9:30 AM" },
                    { 9, "10:00 AM" },
                    { 10, "10:30 AM" },
                    { 11, "11:00 AM" },
                    { 12, "11:30 AM" },
                    { 13, "12:00 PM" },
                    { 14, "12:30 PM" },
                    { 15, "1:00 PM" },
                    { 16, "1:30 PM" },
                    { 17, "2:00 PM" },
                    { 18, "2:30 PM" },
                    { 19, "3:00 PM" },
                    { 20, "3:30 PM" },
                    { 21, "4:00 PM" },
                    { 22, "4:30 PM" },
                    { 23, "5:00 PM" },
                    { 24, "5:30 PM" },
                    { 25, "6:00 PM" }
                }
                );
        }


        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
