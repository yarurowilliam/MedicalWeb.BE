using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Http;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IMedicoBLL
{
    Task<IEnumerable<MedicoDTO>> GetAllAsync();
    Task<MedicoDTO> GetByIdAsync(string id);
    Task<IEnumerable<MedicoDTO>> GetMedicosActivo();
    Task<Medico> InsertAsync(MedicoDTO medicoDTO);
    Task<Medico> UpdateAsync(MedicoDTO medicoDTO);
    Task DeleteAsync(string id);
    Task ActivarAsync(string id);
}