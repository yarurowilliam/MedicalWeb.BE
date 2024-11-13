namespace MedicalWeb.BE.Transversales.Entidades;

public sealed class PersonType
{
    public static class PersonTypes
    {
        public const string NaturalPersonCode = "NATURAL";
        public const string LegalPersonCode = "LEGAL";
    }

    public static readonly PersonType Natural = new(PersonTypes.NaturalPersonCode, 1);
    public static readonly PersonType Legal = new(PersonTypes.LegalPersonCode, 2);

    public int Id { get; }
    public string Code { get; }

    private PersonType(string code, int id)
    {
        Code = code;
        Id = id;
    }

    private PersonType() { }

    public static PersonType[] GetAll()
        => new[] { Natural, Legal };

    public static PersonType GetBy(int id)
        => GetAll().First(x => x.Id == id);
    public static PersonType GetByCode(string code)
        => GetAll().First(x => x.Code == code);

    public static bool IsValidCode(string code)
        => GetAll().Any(x => x.Code == code);
}
