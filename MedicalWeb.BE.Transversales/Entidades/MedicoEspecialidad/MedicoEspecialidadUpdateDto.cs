using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

public class MedicoEspecialidadUpdateDto
{
    public string MedicoNumeroDocumento { get; set; }
    public int EspecialidadId { get; set; }
    public int EspecialidadIdNueva { get; set; }
}