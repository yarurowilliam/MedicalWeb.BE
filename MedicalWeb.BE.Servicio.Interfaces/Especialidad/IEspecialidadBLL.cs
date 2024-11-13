using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IEspecialidadBLL
{
    Task<IEnumerable<Especialidad>> GetEspecialidadesAsync();
    Task<Especialidad> GetEspecialidadByIdAsync(int id);
    Task<Especialidad> CreateEspecialidadAsync(Especialidad especialidad);
    Task<Especialidad> UpdateEspecialidadAsync(Especialidad especialidad);
    Task<Especialidad> DeleteEspecialidadAsync(int id);
}