namespace MedicalWeb.BE.Transversales.Entidades;

public class Valoraciones
{
    public int id { get; set; }
    public string NumMedico { get; set; }
    public decimal Valoracion { get; set; }
    public string Comentario { get; set; }
    public char Estado { get; set; }
}