using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio;

public class EspecialidadDAL : IEspecialidadDAL
{
    //NOTE: La proxima persona que le toque refactorizar esto, recuerde que al momento de traer todas las especialidades, solo se deben traer las activas.
    //DE TODOAS FORMAS CREAR UN METODO QUE LAS TRAIGA TODAS x si acaso..
    
    private readonly MedicalWebDbContext _context;

    public EspecialidadDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task<Especialidad> CreateEspecialidadAsync(Especialidad especialidad)
    {
        _context.Especialidades.Add(especialidad);
        await _context.SaveChangesAsync();
        return especialidad;
    }

    public async Task<bool> DeleteEspecialidadAsync(int id)
    {
        var especialidad = await _context.Especialidades.FindAsync(id);
        if (especialidad != null)
        {
            _context.Especialidades.Remove(especialidad);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Especialidad> GetEspecialidadByIdAsync(int id)
    {
        return await _context.Especialidades.FindAsync(id);
    }

    public async Task<IEnumerable<Especialidad>> GetEspecialidadesAsync()
    {
        return await _context.Especialidades.ToListAsync();
    }

    public async Task<Especialidad> UpdateEspecialidadAsync(Especialidad especialidad)
    {
        _context.Especialidades.Update(especialidad);
        await _context.SaveChangesAsync();
        return especialidad;
    }
    public async Task ActivarAsync(int id)
    {
        var especialidad = await _context.Especialidades
            .FirstOrDefaultAsync(u => u.Id == id);

        if (especialidad != null)
        {
            especialidad.Estado = "ACTIVO";
            await _context.SaveChangesAsync();
        }
    }
}
