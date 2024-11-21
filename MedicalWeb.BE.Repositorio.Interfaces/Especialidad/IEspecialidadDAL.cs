using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IEspecialidadDAL
{
    Task<IEnumerable<Especialidad>> GetEspecialidadesAsync();
    Task<Especialidad> GetEspecialidadByIdAsync(int id);
    Task<Especialidad> CreateEspecialidadAsync(Especialidad especialidad);
    Task<Especialidad> UpdateEspecialidadAsync(Especialidad especialidad);
    Task<Especialidad> DeleteEspecialidadAsync(int id);
}