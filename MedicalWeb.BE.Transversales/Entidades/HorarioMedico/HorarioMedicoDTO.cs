using System.Text.Json.Serialization;
using System.Text.Json;

namespace MedicalWeb.BE.Transversales.Entidades;

public class HorarioMedicoDTO
{
    public int Id { get; set; }
    public string IdentificacionCliente { get; set; }
    public string NombrePaciente { get; set; } // Nuevo campo
    public string NumeroDocumento { get; set; }
    public string NombreMedico { get; set; } // Nuevo campo
    public string Dia { get; set; }
    public string Hora { get; set; }
    public string Estado { get; set; }

    [JsonConverter(typeof(JsonDateOnlyConverter))]
    public DateOnly Fecha { get; set; }
}