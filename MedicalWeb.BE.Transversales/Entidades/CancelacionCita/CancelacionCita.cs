namespace MedicalWeb.BE.Transversales.Entidades;

public class CancelacionCita
{
    public int Id { get; set; }
    public int CitaId { get; set; } 
    public string Motivo { get; set; } 
    public string UsuarioQueCanceloId { get; set; }
    public string NumDocumentoPaciente { get; set; }
    public DateTime FechaCancelacion { get; set; } 
}