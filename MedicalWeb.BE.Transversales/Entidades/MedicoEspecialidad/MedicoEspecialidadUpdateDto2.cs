using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

// Primero, necesitamos modificar el DTO para incluir los campos adicionales
public class MedicoEspecialidadUpdateDto2
{
    public string MedicoNumeroDocumento { get; set; }
    public int EspecialidadId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }
}
