namespace MedicalWeb.BE.Transversales.Entidades;

public class HorarioMedico
{
    public int Id { get; set; }
    public int DiaID { get; set; }
    public int HoraID { get; set; }
    public int EstadoHorarioID { get; set; }
    public string NumeroDocumento { get; set; }
    public string IdentificacionCliente { get; set; }  
}