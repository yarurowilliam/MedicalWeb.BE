using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalWeb.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraConfiguracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentationStatuses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                schema: "dbo",
                columns: table => new
                {
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                    FechaNacimiento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatriculaProfesional = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Universidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnioGraduacion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaSalida = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.NumeroDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationMethods",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "dbo",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "WorkSituation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSituation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afganistán" },
                    { 2, "Albania" },
                    { 3, "Alemania" },
                    { 4, "Andorra" },
                    { 5, "Angola" },
                    { 6, "Antigua y Barbuda" },
                    { 7, "Arabia Saudita" },
                    { 8, "Argelia" },
                    { 9, "Argentina" },
                    { 10, "Armenia" },
                    { 11, "Australia" },
                    { 12, "Austria" },
                    { 13, "Azerbaiyán" },
                    { 14, "Bahamas" },
                    { 15, "Bangladés" },
                    { 16, "Barbados" },
                    { 17, "Baréin" },
                    { 18, "Bélgica" },
                    { 19, "Belice" },
                    { 20, "Benín" },
                    { 21, "Bielorrusia" },
                    { 22, "Birmania" },
                    { 23, "Bolivia" },
                    { 24, "Bosnia y Herzegovina" },
                    { 25, "Botsuana" },
                    { 26, "Brasil" },
                    { 27, "Brunéi" },
                    { 28, "Bulgaria" },
                    { 29, "Burkina Faso" },
                    { 30, "Burundi" },
                    { 31, "Bután" },
                    { 32, "Cabo Verde" },
                    { 33, "Camboya" },
                    { 34, "Camerún" },
                    { 35, "Canadá" },
                    { 36, "Catar" },
                    { 37, "Chad" },
                    { 38, "Chile" },
                    { 39, "China" },
                    { 40, "Chipre" },
                    { 41, "Ciudad del Vaticano" },
                    { 42, "Colombia" },
                    { 43, "Comoras" },
                    { 44, "Congo" },
                    { 45, "Corea del Norte" },
                    { 46, "Corea del Sur" },
                    { 47, "Costa de Marfil" },
                    { 48, "Costa Rica" },
                    { 49, "Croacia" },
                    { 50, "Cuba" },
                    { 51, "Dinamarca" },
                    { 52, "Dominica" },
                    { 53, "Ecuador" },
                    { 54, "Egipto" },
                    { 55, "El Salvador" },
                    { 56, "Emiratos Árabes Unidos" },
                    { 57, "Eritrea" },
                    { 58, "Eslovaquia" },
                    { 59, "Eslovenia" },
                    { 60, "España" },
                    { 61, "Estados Unidos" },
                    { 62, "Estonia" },
                    { 63, "Esuatini" },
                    { 64, "Etiopía" },
                    { 65, "Filipinas" },
                    { 66, "Finlandia" },
                    { 67, "Fiyi" },
                    { 68, "Francia" },
                    { 69, "Gabón" },
                    { 70, "Gambia" },
                    { 71, "Georgia" },
                    { 72, "Ghana" },
                    { 73, "Granada" },
                    { 74, "Grecia" },
                    { 75, "Guatemala" },
                    { 76, "Guinea" },
                    { 77, "Guinea-Bisáu" },
                    { 78, "Guinea Ecuatorial" },
                    { 79, "Guyana" },
                    { 80, "Haití" },
                    { 81, "Honduras" },
                    { 82, "Hungría" },
                    { 83, "India" },
                    { 84, "Indonesia" },
                    { 85, "Irak" },
                    { 86, "Irán" },
                    { 87, "Irlanda" },
                    { 88, "Islandia" },
                    { 89, "Islas Marshall" },
                    { 90, "Islas Salomón" },
                    { 91, "Israel" },
                    { 92, "Italia" },
                    { 93, "Jamaica" },
                    { 94, "Japón" },
                    { 95, "Jordania" },
                    { 96, "Kazajistán" },
                    { 97, "Kenia" },
                    { 98, "Kirguistán" },
                    { 99, "Kiribati" },
                    { 100, "Kuwait" },
                    { 101, "Laos" },
                    { 102, "Lesoto" },
                    { 103, "Letonia" },
                    { 104, "Líbano" },
                    { 105, "Liberia" },
                    { 106, "Libia" },
                    { 107, "Liechtenstein" },
                    { 108, "Lituania" },
                    { 109, "Luxemburgo" },
                    { 110, "Madagascar" },
                    { 111, "Malasia" },
                    { 112, "Malaui" },
                    { 113, "Maldivas" },
                    { 114, "Malí" },
                    { 115, "Malta" },
                    { 116, "Marruecos" },
                    { 117, "Mauricio" },
                    { 118, "Mauritania" },
                    { 119, "México" },
                    { 120, "Micronesia" },
                    { 121, "Moldavia" },
                    { 122, "Mónaco" },
                    { 123, "Mongolia" },
                    { 124, "Montenegro" },
                    { 125, "Mozambique" },
                    { 126, "Namibia" },
                    { 127, "Nauru" },
                    { 128, "Nepal" },
                    { 129, "Nicaragua" },
                    { 130, "Níger" },
                    { 131, "Nigeria" },
                    { 132, "Noruega" },
                    { 133, "Nueva Zelanda" },
                    { 134, "Omán" },
                    { 135, "Países Bajos" },
                    { 136, "Pakistán" },
                    { 137, "Palaos" },
                    { 138, "Panamá" },
                    { 139, "Papúa Nueva Guinea" },
                    { 140, "Paraguay" },
                    { 141, "Perú" },
                    { 142, "Polonia" },
                    { 143, "Portugal" },
                    { 144, "Reino Unido" },
                    { 145, "República Centroafricana" },
                    { 146, "República Checa" },
                    { 147, "República Democrática del Congo" },
                    { 148, "República Dominicana" },
                    { 149, "Ruanda" },
                    { 150, "Rumania" },
                    { 151, "Rusia" },
                    { 152, "Samoa" },
                    { 153, "San Cristóbal y Nieves" },
                    { 154, "San Marino" },
                    { 155, "San Vicente y las Granadinas" },
                    { 156, "Santa Lucía" },
                    { 157, "Santo Tomé y Príncipe" },
                    { 158, "Senegal" },
                    { 159, "Serbia" },
                    { 160, "Seychelles" },
                    { 161, "Sierra Leona" },
                    { 162, "Singapur" },
                    { 163, "Siria" },
                    { 164, "Somalia" },
                    { 165, "Sri Lanka" },
                    { 166, "Suazilandia" },
                    { 167, "Sudáfrica" },
                    { 168, "Sudán" },
                    { 169, "Sudán del Sur" },
                    { 170, "Suecia" },
                    { 171, "Suiza" },
                    { 172, "Surinam" },
                    { 173, "Tailandia" },
                    { 174, "Tanzania" },
                    { 175, "Tayikistán" },
                    { 176, "Timor Oriental" },
                    { 177, "Togo" },
                    { 178, "Tonga" },
                    { 179, "Trinidad y Tobago" },
                    { 180, "Túnez" },
                    { 181, "Turkmenistán" },
                    { 182, "Turquía" },
                    { 183, "Tuvalu" },
                    { 184, "Ucrania" },
                    { 185, "Uganda" },
                    { 186, "Uruguay" },
                    { 187, "Uzbekistán" },
                    { 188, "Vanuatu" },
                    { 189, "Venezuela" },
                    { 190, "Vietnam" },
                    { 191, "Yemen" },
                    { 192, "Yibuti" },
                    { 193, "Zambia" },
                    { 194, "Zimbabue" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DocumentationStatuses",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "INCOMPLETED" },
                    { 2, "VALIDATION_PENDING" },
                    { 3, "VALIDATED" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Soltero/a" },
                    { 2, "Casado/a" },
                    { 3, "Unión libre o unión de hecho" },
                    { 4, "Separado/a" },
                    { 5, "Divorciado/a" },
                    { 6, "Viudo/a" }
                });

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afgana" },
                    { 2, "Albanesa" },
                    { 3, "Alemana" },
                    { 4, "Andorrana" },
                    { 5, "Angoleña" },
                    { 6, "Antiguana" },
                    { 7, "Saudí" },
                    { 8, "Argelina" },
                    { 9, "Argentina" },
                    { 10, "Armenia" },
                    { 11, "Australiana" },
                    { 12, "Austriaca" },
                    { 13, "Azerbaiyana" },
                    { 14, "Bahameña" },
                    { 15, "Bangladesí" },
                    { 16, "Barbadense" },
                    { 17, "Bareiní" },
                    { 18, "Belga" },
                    { 19, "Beliceña" },
                    { 20, "Beninesa" },
                    { 21, "Bielorrusa" },
                    { 22, "Birmana" },
                    { 23, "Boliviana" },
                    { 24, "Bosnia" },
                    { 25, "Botswanesa" },
                    { 26, "Brasileña" },
                    { 27, "Bruneana" },
                    { 28, "Búlgara" },
                    { 29, "Burkinesa" },
                    { 30, "Burundesa" },
                    { 31, "Butanesa" },
                    { 32, "Caboverdiana" },
                    { 33, "Camboyana" },
                    { 34, "Camerunesa" },
                    { 35, "Canadiense" },
                    { 36, "Catarí" },
                    { 37, "Chadiana" },
                    { 38, "Chilena" },
                    { 39, "China" },
                    { 40, "Chipriota" },
                    { 41, "Vaticana" },
                    { 42, "Colombiana" },
                    { 43, "Comorense" },
                    { 44, "Congoleña" },
                    { 45, "Norcoreana" },
                    { 46, "Surcoreana" },
                    { 47, "Marfileña" },
                    { 48, "Costarricense" },
                    { 49, "Croata" },
                    { 50, "Cubana" },
                    { 51, "Danesa" },
                    { 52, "Dominiquesa" },
                    { 53, "Ecuatoriana" },
                    { 54, "Egipcia" },
                    { 55, "Salvadoreña" },
                    { 56, "Emiratí" },
                    { 57, "Eritrea" },
                    { 58, "Eslovaca" },
                    { 59, "Eslovena" },
                    { 60, "Española" },
                    { 61, "Estadounidense" },
                    { 62, "Estonia" },
                    { 63, "Suazi" },
                    { 64, "Etíope" },
                    { 65, "Filipina" },
                    { 66, "Finlandesa" },
                    { 67, "Fiyiana" },
                    { 68, "Francesa" },
                    { 69, "Gabonesa" },
                    { 70, "Gambiana" },
                    { 71, "Georgiana" },
                    { 72, "Ghanesa" },
                    { 73, "Granadina" },
                    { 74, "Griega" },
                    { 75, "Guatemalteca" },
                    { 76, "Guineana" },
                    { 77, "Bisauguineana" },
                    { 78, "Ecuatoguineana" },
                    { 79, "Guyana" },
                    { 80, "Haitiana" },
                    { 81, "Hondureña" },
                    { 82, "Húngara" },
                    { 83, "India" },
                    { 84, "Indonesia" },
                    { 85, "Iraquí" },
                    { 86, "Iraní" },
                    { 87, "Irlandesa" },
                    { 88, "Islandesa" },
                    { 89, "Marshalesa" },
                    { 90, "Salomonense" },
                    { 91, "Israelí" },
                    { 92, "Italiana" },
                    { 93, "Jamaiquina" },
                    { 94, "Japonesa" },
                    { 95, "Jordana" },
                    { 96, "Kazaja" },
                    { 97, "Kenia" },
                    { 98, "Kirguís" },
                    { 99, "Kiribatiana" },
                    { 100, "Kuwaití" },
                    { 101, "Laosiana" },
                    { 102, "Lesotense" },
                    { 103, "Letona" },
                    { 104, "Libanesa" },
                    { 105, "Liberiana" },
                    { 106, "Libia" },
                    { 107, "Liechtensteiniana" },
                    { 108, "Lituana" },
                    { 109, "Luxemburguesa" },
                    { 110, "Macedonia" },
                    { 111, "Madagascarense" },
                    { 112, "Malasia" },
                    { 113, "Malauí" },
                    { 114, "Maldiva" },
                    { 115, "Maliense" },
                    { 116, "Maltesa" },
                    { 117, "Marroquí" },
                    { 118, "Mauriciana" },
                    { 119, "Mauritana" },
                    { 120, "Mexicana" },
                    { 121, "Micronesia" },
                    { 122, "Moldava" },
                    { 123, "Monegasca" },
                    { 124, "Mongola" },
                    { 125, "Montenegrina" },
                    { 126, "Mozambiqueña" },
                    { 127, "Namibia" },
                    { 128, "Nauruana" },
                    { 129, "Nepalí" },
                    { 130, "Nicaragüense" },
                    { 131, "Nigerina" },
                    { 132, "Nigeriana" },
                    { 133, "Noruega" },
                    { 134, "Neozelandesa" },
                    { 135, "Omaní" },
                    { 136, "Neerlandesa" },
                    { 137, "Pakistaní" },
                    { 138, "Palauana" },
                    { 139, "Panameña" },
                    { 140, "Papú" },
                    { 141, "Paraguaya" },
                    { 142, "Peruana" },
                    { 143, "Polaca" },
                    { 144, "Portuguesa" },
                    { 145, "Británica" },
                    { 146, "Centroafricana" },
                    { 147, "Checa" },
                    { 148, "Congoleña" },
                    { 149, "Dominicana" },
                    { 150, "Ruandesa" },
                    { 151, "Rumana" },
                    { 152, "Rusa" },
                    { 153, "Samoana" },
                    { 154, "Sancristobaleña" },
                    { 155, "Sanmarinense" },
                    { 156, "Sanvicentina" },
                    { 157, "Santalucense" },
                    { 158, "Santomense" },
                    { 159, "Senegalesa" },
                    { 160, "Serbia" },
                    { 161, "Seychelense" },
                    { 162, "Sierraleonesa" },
                    { 163, "Singapurense" },
                    { 164, "Siria" },
                    { 165, "Somalí" },
                    { 166, "Ceilanesa" },
                    { 167, "Sudafricana" },
                    { 168, "Sudanesa" },
                    { 169, "Sur Sudanesa" },
                    { 170, "Sueca" },
                    { 171, "Suiza" },
                    { 172, "Surinamesa" },
                    { 173, "Tailandesa" },
                    { 174, "Tanzana" },
                    { 175, "Tayika" },
                    { 176, "Timorense" },
                    { 177, "Togolesa" },
                    { 178, "Tongana" },
                    { 179, "Trinitense" },
                    { 180, "Tunecina" },
                    { 181, "Turcomana" },
                    { 182, "Turca" },
                    { 183, "Tuvaluana" },
                    { 184, "Ucraniana" },
                    { 185, "Ugandesa" },
                    { 186, "Uruguaya" },
                    { 187, "Uzbeca" },
                    { 188, "Vanuatuense" },
                    { 189, "Venezolana" },
                    { 190, "Vietnamita" },
                    { 191, "Yemení" },
                    { 192, "Yibutiana" },
                    { 193, "Zambiana" },
                    { 194, "Zimbabuense" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NotificationMethods",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "EMAIL" },
                    { 2, "WHATSAPP" }
                });

            migrationBuilder.InsertData(
                table: "WorkSituation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Empleado" },
                    { 2, "Independiente" },
                    { 3, "Desempleado" },
                    { 4, "Jubilado" },
                    { 5, "Estudiante" },
                    { 6, "Cuidador(a) del hogar" },
                    { 7, "Empleado público" },
                    { 8, "Pensionado" },
                    { 9, "Baja laboral" },
                    { 10, "Empleado a tiempo parcial" },
                    { 11, "Empleado eventual" },
                    { 12, "Empresario" },
                    { 13, "Prejubilado" },
                    { 14, "Trabajador en prácticas" },
                    { 15, "Otro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentationStatuses_Code",
                schema: "dbo",
                table: "DocumentationStatuses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationMethods_Code",
                schema: "dbo",
                table: "NotificationMethods",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "DocumentationStatuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "Medicos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "NotificationMethods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WorkSituation");
        }
    }
}
