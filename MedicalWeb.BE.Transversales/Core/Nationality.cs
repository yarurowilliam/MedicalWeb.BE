﻿using MedicalWeb.BE.Transversales.Common;
namespace MedicalWeb.BE.Transversales.Core;

public class Nationality : EnumEntity
{
    public string Name { get; set; } = null!;

    public static IEnumerable<Nationality> GetAll() => new List<Nationality>
            {
                new Nationality { Id = 1, Name = "Afgana" },
                new Nationality { Id = 2, Name = "Albanesa" },
                new Nationality { Id = 3, Name = "Alemana" },
                new Nationality { Id = 4, Name = "Andorrana" },
                new Nationality { Id = 5, Name = "Angoleña" },
                new Nationality { Id = 6, Name = "Antiguana" },
                new Nationality { Id = 7, Name = "Saudí" },
                new Nationality { Id = 8, Name = "Argelina" },
                new Nationality { Id = 9, Name = "Argentina" },
                new Nationality { Id = 10, Name = "Armenia" },
                new Nationality { Id = 11, Name = "Australiana" },
                new Nationality { Id = 12, Name = "Austriaca" },
                new Nationality { Id = 13, Name = "Azerbaiyana" },
                new Nationality { Id = 14, Name = "Bahameña" },
                new Nationality { Id = 15, Name = "Bangladesí" },
                new Nationality { Id = 16, Name = "Barbadense" },
                new Nationality { Id = 17, Name = "Bareiní" },
                new Nationality { Id = 18, Name = "Belga" },
                new Nationality { Id = 19, Name = "Beliceña" },
                new Nationality { Id = 20, Name = "Beninesa" },
                new Nationality { Id = 21, Name = "Bielorrusa" },
                new Nationality { Id = 22, Name = "Birmana" },
                new Nationality { Id = 23, Name = "Boliviana" },
                new Nationality { Id = 24, Name = "Bosnia" },
                new Nationality { Id = 25, Name = "Botswanesa" },
                new Nationality { Id = 26, Name = "Brasileña" },
                new Nationality { Id = 27, Name = "Bruneana" },
                new Nationality { Id = 28, Name = "Búlgara" },
                new Nationality { Id = 29, Name = "Burkinesa" },
                new Nationality { Id = 30, Name = "Burundesa" },
                new Nationality { Id = 31, Name = "Butanesa" },
                new Nationality { Id = 32, Name = "Caboverdiana" },
                new Nationality { Id = 33, Name = "Camboyana" },
                new Nationality { Id = 34, Name = "Camerunesa" },
                new Nationality { Id = 35, Name = "Canadiense" },
                new Nationality { Id = 36, Name = "Catarí" },
                new Nationality { Id = 37, Name = "Chadiana" },
                new Nationality { Id = 38, Name = "Chilena" },
                new Nationality { Id = 39, Name = "China" },
                new Nationality { Id = 40, Name = "Chipriota" },
                new Nationality { Id = 41, Name = "Vaticana" },
                new Nationality { Id = 42, Name = "Colombiana" },
                new Nationality { Id = 43, Name = "Comorense" },
                new Nationality { Id = 44, Name = "Congoleña" },
                new Nationality { Id = 45, Name = "Norcoreana" },
                new Nationality { Id = 46, Name = "Surcoreana" },
                new Nationality { Id = 47, Name = "Marfileña" },
                new Nationality { Id = 48, Name = "Costarricense" },
                new Nationality { Id = 49, Name = "Croata" },
                new Nationality { Id = 50, Name = "Cubana" },
                new Nationality { Id = 51, Name = "Danesa" },
                new Nationality { Id = 52, Name = "Dominiquesa" },
                new Nationality { Id = 53, Name = "Ecuatoriana" },
                new Nationality { Id = 54, Name = "Egipcia" },
                new Nationality { Id = 55, Name = "Salvadoreña" },
                new Nationality { Id = 56, Name = "Emiratí" },
                new Nationality { Id = 57, Name = "Eritrea" },
                new Nationality { Id = 58, Name = "Eslovaca" },
                new Nationality { Id = 59, Name = "Eslovena" },
                new Nationality { Id = 60, Name = "Española" },
                new Nationality { Id = 61, Name = "Estadounidense" },
                new Nationality { Id = 62, Name = "Estonia" },
                new Nationality { Id = 63, Name = "Suazi" },
                new Nationality { Id = 64, Name = "Etíope" },
                new Nationality { Id = 65, Name = "Filipina" },
                new Nationality { Id = 66, Name = "Finlandesa" },
                new Nationality { Id = 67, Name = "Fiyiana" },
                new Nationality { Id = 68, Name = "Francesa" },
                new Nationality { Id = 69, Name = "Gabonesa" },
                new Nationality { Id = 70, Name = "Gambiana" },
                new Nationality { Id = 71, Name = "Georgiana" },
                new Nationality { Id = 72, Name = "Ghanesa" },
                new Nationality { Id = 73, Name = "Granadina" },
                new Nationality { Id = 74, Name = "Griega" },
                new Nationality { Id = 75, Name = "Guatemalteca" },
                new Nationality { Id = 76, Name = "Guineana" },
                new Nationality { Id = 77, Name = "Bisauguineana" },
                new Nationality { Id = 78, Name = "Ecuatoguineana" },
                new Nationality { Id = 79, Name = "Guyana" },
                new Nationality { Id = 80, Name = "Haitiana" },
                new Nationality { Id = 81, Name = "Hondureña" },
                new Nationality { Id = 82, Name = "Húngara" },
                new Nationality { Id = 83, Name = "India" },
                new Nationality { Id = 84, Name = "Indonesia" },
                new Nationality { Id = 85, Name = "Iraquí" },
                new Nationality { Id = 86, Name = "Iraní" },
                new Nationality { Id = 87, Name = "Irlandesa" },
                new Nationality { Id = 88, Name = "Islandesa" },
                new Nationality { Id = 89, Name = "Marshalesa" },
                new Nationality { Id = 90, Name = "Salomonense" },
                new Nationality { Id = 91, Name = "Israelí" },
                new Nationality { Id = 92, Name = "Italiana" },
                new Nationality { Id = 93, Name = "Jamaiquina" },
                new Nationality { Id = 94, Name = "Japonesa" },
                new Nationality { Id = 95, Name = "Jordana" },
                new Nationality { Id = 96, Name = "Kazaja" },
                new Nationality { Id = 97, Name = "Kenia" },
                new Nationality { Id = 98, Name = "Kirguís" },
                new Nationality { Id = 99, Name = "Kiribatiana" },
                new Nationality { Id = 100, Name = "Kuwaití" },
                new Nationality { Id = 101, Name = "Laosiana" },
                new Nationality { Id = 102, Name = "Lesotense" },
                new Nationality { Id = 103, Name = "Letona" },
                new Nationality { Id = 104, Name = "Libanesa" },
                new Nationality { Id = 105, Name = "Liberiana" },
                new Nationality { Id = 106, Name = "Libia" },
                new Nationality { Id = 107, Name = "Liechtensteiniana" },
                new Nationality { Id = 108, Name = "Lituana" },
                new Nationality { Id = 109, Name = "Luxemburguesa" },
                new Nationality { Id = 110, Name = "Macedonia" },
                new Nationality { Id = 111, Name = "Madagascarense" },
                new Nationality { Id = 112, Name = "Malasia" },
                new Nationality { Id = 113, Name = "Malauí" },
                new Nationality { Id = 114, Name = "Maldiva" },
                new Nationality { Id = 115, Name = "Maliense" },
                new Nationality { Id = 116, Name = "Maltesa" },
                new Nationality { Id = 117, Name = "Marroquí" },
                new Nationality { Id = 118, Name = "Mauriciana" },
                new Nationality { Id = 119, Name = "Mauritana" },
                new Nationality { Id = 120, Name = "Mexicana" },
                new Nationality { Id = 121, Name = "Micronesia" },
                new Nationality { Id = 122, Name = "Moldava" },
                new Nationality { Id = 123, Name = "Monegasca" },
                new Nationality { Id = 124, Name = "Mongola" },
                new Nationality { Id = 125, Name = "Montenegrina" },
                new Nationality { Id = 126, Name = "Mozambiqueña" },
                new Nationality { Id = 127, Name = "Namibia" },
                new Nationality { Id = 128, Name = "Nauruana" },
                new Nationality { Id = 129, Name = "Nepalí" },
                new Nationality { Id = 130, Name = "Nicaragüense" },
                new Nationality { Id = 131, Name = "Nigerina" },
                new Nationality { Id = 132, Name = "Nigeriana" },
                new Nationality { Id = 133, Name = "Noruega" },
                new Nationality { Id = 134, Name = "Neozelandesa" },
                new Nationality { Id = 135, Name = "Omaní" },
                new Nationality { Id = 136, Name = "Neerlandesa" },
                new Nationality { Id = 137, Name = "Pakistaní" },
                new Nationality { Id = 138, Name = "Palauana" },
                new Nationality { Id = 139, Name = "Panameña" },
                new Nationality { Id = 140, Name = "Papú" },
                new Nationality { Id = 141, Name = "Paraguaya" },
                new Nationality { Id = 142, Name = "Peruana" },
                new Nationality { Id = 143, Name = "Polaca" },
                new Nationality { Id = 144, Name = "Portuguesa" },
                new Nationality { Id = 145, Name = "Británica" },
                new Nationality { Id = 146, Name = "Centroafricana" },
                new Nationality { Id = 147, Name = "Checa" },
                new Nationality { Id = 148, Name = "Congoleña" },
                new Nationality { Id = 149, Name = "Dominicana" },
                new Nationality { Id = 150, Name = "Ruandesa" },
                new Nationality { Id = 151, Name = "Rumana" },
                new Nationality { Id = 152, Name = "Rusa" },
                new Nationality { Id = 153, Name = "Samoana" },
                new Nationality { Id = 154, Name = "Sancristobaleña" },
                new Nationality { Id = 155, Name = "Sanmarinense" },
                new Nationality { Id = 156, Name = "Sanvicentina" },
                new Nationality { Id = 157, Name = "Santalucense" },
                new Nationality { Id = 158, Name = "Santomense" },
                new Nationality { Id = 159, Name = "Senegalesa" },
                new Nationality { Id = 160, Name = "Serbia" },
                new Nationality { Id = 161, Name = "Seychelense" },
                new Nationality { Id = 162, Name = "Sierraleonesa" },
                new Nationality { Id = 163, Name = "Singapurense" },
                new Nationality { Id = 164, Name = "Siria" },
                new Nationality { Id = 165, Name = "Somalí" },
                new Nationality { Id = 166, Name = "Ceilanesa" },
                new Nationality { Id = 167, Name = "Sudafricana" },
                new Nationality { Id = 168, Name = "Sudanesa" },
                new Nationality { Id = 169, Name = "Sur Sudanesa" },
                new Nationality { Id = 170, Name = "Sueca" },
                new Nationality { Id = 171, Name = "Suiza" },
                new Nationality { Id = 172, Name = "Surinamesa" },
                new Nationality { Id = 173, Name = "Tailandesa" },
                new Nationality { Id = 174, Name = "Tanzana" },
                new Nationality { Id = 175, Name = "Tayika" },
                new Nationality { Id = 176, Name = "Timorense" },
                new Nationality { Id = 177, Name = "Togolesa" },
                new Nationality { Id = 178, Name = "Tongana" },
                new Nationality { Id = 179, Name = "Trinitense" },
                new Nationality { Id = 180, Name = "Tunecina" },
                new Nationality { Id = 181, Name = "Turcomana" },
                new Nationality { Id = 182, Name = "Turca" },
                new Nationality { Id = 183, Name = "Tuvaluana" },
                new Nationality { Id = 184, Name = "Ucraniana" },
                new Nationality { Id = 185, Name = "Ugandesa" },
                new Nationality { Id = 186, Name = "Uruguaya" },
                new Nationality { Id = 187, Name = "Uzbeca" },
                new Nationality { Id = 188, Name = "Vanuatuense" },
                new Nationality { Id = 189, Name = "Venezolana" },
                new Nationality { Id = 190, Name = "Vietnamita" },
                new Nationality { Id = 191, Name = "Yemení" },
                new Nationality { Id = 192, Name = "Yibutiana" },
                new Nationality { Id = 193, Name = "Zambiana" },
                new Nationality { Id = 194, Name = "Zimbabuense" }
            };
}