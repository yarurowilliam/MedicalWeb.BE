using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IPacientesDAL
{
    Task<IEnumerable<Pacientes>> GetAllAsync();
    Task<Pacientes> GetByIdAsync(string numeroDocumento);
    Task<PacientesDTO1> InsertAsync(PacientesDTO1 pacientes);
    Task<PacientesDTO1> UpdateAsync(PacientesDTO1 pacientes);
    Task DeleteAsync(string numeroDocumento);
}