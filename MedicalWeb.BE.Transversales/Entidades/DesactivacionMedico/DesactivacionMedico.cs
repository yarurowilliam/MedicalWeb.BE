namespace MedicalWeb.BE.Transversales.Entidades
{
    public class DesactivacionMedico
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } 
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }
}