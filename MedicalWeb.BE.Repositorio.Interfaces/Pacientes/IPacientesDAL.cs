using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IPacientesDAL
{
    Task<IEnumerable<Pacientes>> GetAllAsync();
    Task<Pacientes> GetByIdAsync(string numeroDocumento);
    Task<Pacientes> InsertAsync(Pacientes pacientesDto);
    Task<Pacientes> UpdateAsync(Pacientes pacientesDto);
    Task DeleteAsync(string id);
}
