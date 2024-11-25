
namespace MedicalWeb.BE.Transversales;

public sealed class EstadoAlerta
{
    public static readonly EstadoAlerta Activo = new(1, Estados.Activo);
    public static readonly EstadoAlerta Resuelto = new(2, Estados.Resuelto);
    public static readonly EstadoAlerta Omitido = new(3, Estados.Omitido);
    public static class Estados
    {
        public const string Activo = "ACTIVO";
        public const string Resuelto = "RESUELTO";
        public const string Omitido = "OMITIDO";
    }

    public int Id { get; private set; }

    public string EstadoName { get; private set; }
    private EstadoAlerta(int id, string estadoName)
    {
        Id = id;
        EstadoName = estadoName;
    }
    public EstadoAlerta() { }

    public static EstadoAlerta[] GetAll()
        => new[] { Activo, Resuelto, Omitido };
    public static EstadoAlerta GetById(int id)
        => GetAll().First(x => x.Id == id);
    public static EstadoAlerta GetByName(string name)
        => GetAll().First(x => x.EstadoName == name);
    public static bool IsValidName(string name)
        => GetAll().Any(x => x.EstadoName == name);    
}