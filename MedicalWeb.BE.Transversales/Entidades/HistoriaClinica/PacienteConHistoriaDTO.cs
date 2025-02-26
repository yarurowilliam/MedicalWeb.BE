using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Entidades;

    public class PacienteConHistoriaDTO
    {
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime UltimaConsulta { get; set; }
    }

