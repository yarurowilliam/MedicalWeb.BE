using MedicalWeb.BE.Repositorio;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio;

public class EspecialidadBLL : IEspecialidadBLL
{
    private readonly IEspecialidadDAL _especialidadDAL;

    public EspecialidadBLL(IEspecialidadDAL especialidadDAL)
    {
        _especialidadDAL = especialidadDAL;
    }

    public async Task<Especialidad> CreateEspecialidadAsync(Especialidad especialidad)
    {
        return await _especialidadDAL.CreateEspecialidadAsync(especialidad);
    }

    public async Task<Especialidad> DeleteEspecialidadAsync(int id)
    {
        return await _especialidadDAL.DeleteEspecialidadAsync(id);
    }

    public async Task<Especialidad> GetEspecialidadByIdAsync(int id)
    {
        return await _especialidadDAL.GetEspecialidadByIdAsync(id);
    }

    public async Task<IEnumerable<Especialidad>> GetEspecialidadesAsync()
    {
        return await _especialidadDAL.GetEspecialidadesAsync();
    }

    public async Task<Especialidad> UpdateEspecialidadAsync(Especialidad especialidad)
    {
        return await _especialidadDAL.UpdateEspecialidadAsync(especialidad);
    }
    public async Task ActivarAsync(int id)
    {
        await _especialidadDAL.ActivarAsync(id);
    }
}