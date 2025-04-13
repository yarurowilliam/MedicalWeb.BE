using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

public class MedicamentoRecetado
{
    public int ID { get; set; }
    public int RecetaID { get; set; }

    public string NombreMedicamento { get; set; }
    public string Concentracion { get; set; }
    public string FormaFarmaceutica { get; set; }
    public int CantidadRecetada { get; set; }
    public string InstruccionesUso { get; set; }
    [JsonIgnore]
    public Receta Receta { get; set; }
}
