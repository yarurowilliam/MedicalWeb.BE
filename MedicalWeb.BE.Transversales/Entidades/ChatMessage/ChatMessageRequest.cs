using Microsoft.AspNetCore.Http;

namespace MedicalWeb.BE.Transversales.Entidades
{
    public class ChatMessageRequest
    {
        public int HorarioMedicoId { get; set; } 
        public string PacienteId { get; set; } 
        public string Mensaje { get; set; }
        public IFormFile? Archivo { get; set; } 
        public bool EsMedico { get; set; }
    }
}