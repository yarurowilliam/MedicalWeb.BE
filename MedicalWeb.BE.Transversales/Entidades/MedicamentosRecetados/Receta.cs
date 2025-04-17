using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

public class Receta
{
    public int ID { get; set; }

    public string NumeroDocumentoPaciente { get; set; } 
    public string NumeroDocumentoMedico { get; set; }   

    public DateTime FechaHora { get; set; }
    public string Diagnostico { get; set; }

    [JsonIgnore]
    public Medico Medico { get; set; }
   
}
