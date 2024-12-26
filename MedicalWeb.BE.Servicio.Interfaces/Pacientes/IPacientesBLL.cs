using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IPacientesBLL
{
    Task<IEnumerable<PacientesDTO>> GetAllAsync();
    Task<PacientesDTO> GetByIdAsync(string numeroDocumento);
    Task<Pacientes> InsertAsync(Pacientes pacientes);
    Task<Pacientes> UpdateAsync(Pacientes pacientes);
    Task DeleteAsync(string id);
}