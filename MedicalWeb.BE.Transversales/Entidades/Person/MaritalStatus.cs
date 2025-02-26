using MedicalWeb.BE.Transversales.Common;
namespace MedicalWeb.BE.Transversales.Entidades;

public class MaritalStatus : EnumEntity
{
    public string Name { get; set; } = null!;

    public static IEnumerable<MaritalStatus> GetAll() =>
        new List<MaritalStatus>()
        {
            new MaritalStatus { Id = 1, Name = "Soltero/a" },
            new MaritalStatus { Id = 2, Name = "Casado/a" },
            new MaritalStatus { Id = 3, Name = "Unión libre o unión de hecho" },
            new MaritalStatus { Id = 4, Name = "Separado/a" },
            new MaritalStatus { Id = 5, Name = "Divorciado/a" },
            new MaritalStatus { Id = 6, Name = "Viudo/a" },
       };
}