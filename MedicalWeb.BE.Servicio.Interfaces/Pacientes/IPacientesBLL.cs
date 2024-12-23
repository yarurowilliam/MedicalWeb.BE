using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IPacientesBLL
{
    Task<IEnumerable<PacientesDTO>> GetAllAsync();
    Task<PacientesDTO> GetByIdAsync(string numeroDocumento);
    Task<PacientesDTO1> InsertAsync(PacientesDTO1 pacientes);
    Task<PacientesDTO1> UpdateAsync(PacientesDTO1 pacientes);
    Task DeleteAsync(string numeroDocumento);
}