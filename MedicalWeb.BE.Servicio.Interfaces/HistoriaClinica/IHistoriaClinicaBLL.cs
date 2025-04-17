using MedicalWeb.BE.Transversales.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IHistoriaClinicaBLL
{
    Task<IEnumerable<HistoriaClinicaDTO>> GetAllAsync();
    Task<IEnumerable<HistoriaClinicaDTO>> ObtenerHistoriasClinicasPorMedicoAsync(int idMedico);
    Task<IEnumerable<HistoriaClinicaDTO>> ObtenerHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente); 
    Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO);
    Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO);
    Task DeleteAsync(string numeroDocumento);
    Task<IEnumerable<PacienteConHistoriaDTO>> ObtenerPacientesConHistoriasClinicasAsync();
    Task<IEnumerable<HistoriaClinicaDTO>> ObtenerTodasHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente);
    Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente);
}
