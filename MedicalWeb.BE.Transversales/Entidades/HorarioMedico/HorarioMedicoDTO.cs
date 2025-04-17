using System.Text.Json.Serialization;
using System.Text.Json;

namespace MedicalWeb.BE.Transversales.Entidades;

public class HorarioMedicoDTO
{
    public int Id { get; set; }
    public string IdentificacionCliente { get; set; }
    public string NombrePaciente { get; set; }
    public string NumeroDocumento { get; set; }
    public string NombreMedico { get; set; } 
    public string Dia { get; set; }
    public string Hora { get; set; }
    public string Estado { get; set; }
    public string SalaId { get; set; } 
    public string Correo { get; set; }

    [JsonConverter(typeof(JsonDateOnlyConverter))]
    public DateOnly Fecha { get; set; }
}