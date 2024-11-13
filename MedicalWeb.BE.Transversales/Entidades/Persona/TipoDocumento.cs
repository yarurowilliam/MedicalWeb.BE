namespace MedicalWeb.BE.Transversales.Entidades;

public class TipoDocumento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Abreviatura { get; set; }
    public string Descripcion { get; set; }
    public bool Activo { get; set; }
}
