using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

public class IncapacidadDTO
{
    [JsonIgnore]
    public int ID { get; set; }
    public string NumeroDocumentoPaciente { get; set; }
    public string NumeroDocumentoMedico { get; set; }
    public DateTime FechaGeneracion { get; set; }
    public string Diagnostico { get; set; }
    public string Origen { get; set; }
    public string Clasificacion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int DuracionDias { get; set; }
    public string? NumeroPrescripcionSustituida { get; set; }

}
