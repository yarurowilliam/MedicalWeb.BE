using MedicalWeb.BE.Transversales.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IHistoriaClinicaDAL
{
    Task<IEnumerable<HistoriaClinica>> GetAllAsync();
    Task<IEnumerable<HistoriaClinica>> ObtenerHistoriasClinicasPorMedicoAsync(int idMedico);
    Task<IEnumerable<HistoriaClinica>> ObtenerHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente); 
    Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO);
    Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO);
    Task DeleteAsync(string numeroDocumento);

}
