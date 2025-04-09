using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

public class MedicoEspecialidadUpdateListDto
{
    public string MedicoNumeroDocumento { get; set; }
    public List<int> EspecialidadesIds { get; set; }
}