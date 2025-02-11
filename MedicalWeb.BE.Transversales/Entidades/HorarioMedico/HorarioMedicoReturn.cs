namespace MedicalWeb.BE.Transversales.Entidades;

public class HorarioMedicoReturn
{
    public int Id { get; set; }
    public int DiaID { get; set; }
    public int HoraID { get; set; }
    public int EstadoHorarioID { get; set; }
    public string NumeroDocumento { get; set; }
    public string IdentificacionCliente { get; set; }
    public string SalaId { get; set; }
}
