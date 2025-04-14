using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades.MedicamentosRecetados
{
  
    public class RecetaCompletaDTO
    {
        public string NumeroDocumentoPaciente { get; set; }
        public string NumeroDocumentoMedico { get; set; }
        public DateTime FechaHora { get; set; }
        public string Diagnostico { get; set; }

        public List<MedicamentoDTO> Medicamentos { get; set; }
    }

    public class MedicamentoDTO
    {
        public string NombreMedicamento { get; set; }
        public string Concentracion { get; set; }
        public string FormaFarmaceutica { get; set; }
        public int CantidadRecetada { get; set; }
        public string InstruccionesUso { get; set; }
    }

}
