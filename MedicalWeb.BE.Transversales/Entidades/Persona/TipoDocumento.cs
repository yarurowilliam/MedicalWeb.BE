namespace MedicalWeb.BE.Transversales.Entidades;

public class TipoDocumento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Abreviatura { get; set; }
    public string Descripcion { get; set; }
    public int IdPais { get; set; }
    public string Estado { get; set; }
}