namespace MedicalWeb.BE.Transversales.Entidades;

public class Reporte
{
    public int Id { get; set; }
    public string Motivo { get; set; } 
    public string Mensaje { get; set; }
    public int Estado { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaCreacion { get; set; }
}