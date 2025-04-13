using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Transversales.Entidades.MedicamentosRecetados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IMedicamentosRecetadosDAL
{
    Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente);
    Task InsertarRecetaConMedicamentosAsync(RecetaCompletaDTO recetaDTO);


}
