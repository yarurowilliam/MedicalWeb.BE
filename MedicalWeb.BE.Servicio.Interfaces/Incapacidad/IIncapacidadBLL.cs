using MedicalWeb.BE.Transversales.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IIncapacidadBLL
{
    Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente);
    Task InsertarIncapacidadAsync(IncapacidadDTO incapacidadDTO);

}
