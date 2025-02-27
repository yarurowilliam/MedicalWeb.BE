using System;

namespace MedicalWeb.BE.Transversales.Entidades
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int HorarioMedicoId { get; set; } 
        public string PacienteId { get; set; } 
        public string Mensaje { get; set; } 
        public string ArchivoUrl { get; set; } 
        public DateTime FechaEnvio { get; set; } 
        public bool EsMedico { get; set; } 
    }
}
