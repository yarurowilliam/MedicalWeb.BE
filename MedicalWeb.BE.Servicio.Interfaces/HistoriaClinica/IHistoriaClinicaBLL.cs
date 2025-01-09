using MedicalWeb.BE.Transversales.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IHistoriaClinicaBLL
{
    Task<IEnumerable<HistoriaClinicaDTO>> GetAllAsync();
    Task<HistoriaClinicaDTO> GetByIdAsync(string numeroDocumento);
    Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO);
    Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO);
    Task DeleteAsync(string numeroDocumento);
}
