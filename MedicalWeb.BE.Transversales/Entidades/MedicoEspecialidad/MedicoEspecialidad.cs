using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MedicalWeb.BE.Transversales.Entidades;

public class MedicoEspecialidad
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Medico")]
    public string MedicoNumeroDocumento { get; set; }

    [ForeignKey("Especialidad")]
    public int EspecialidadId { get; set; }

    [JsonIgnore]
    public Medico Medico { get; set; }
    
    [JsonIgnore]
    public Especialidad Especialidad { get; set; }
}