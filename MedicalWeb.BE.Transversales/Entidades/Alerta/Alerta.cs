namespace MedicalWeb.BE.Transversales.Entidades;
    public class Alerta
    {
    public int IdAlerta { get; set; } 
    public string IdUsuario { get; set; } 
    public Usuario Usuario { get; set; } 
    public DateTime FechaRegistro { get; set; } 
    public string Comentario { get; set; }
    public int EstadoAlertaId { get; set; }
    public EstadoAlerta Estado { get; set; } 
    public DateTime? FechaCierre { get; set; } 
}