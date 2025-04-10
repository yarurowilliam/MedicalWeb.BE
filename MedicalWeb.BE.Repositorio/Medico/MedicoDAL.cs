using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio;

public class MedicoDAL : IMedicoDAL
{
    //IMPLEMENTA EL CONTEXTO
    private readonly MedicalWebDbContext _context;

    public MedicoDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(string id)
    {
        var medico = await _context.Medicos
            .FirstOrDefaultAsync(u => u.NumeroDocumento == id);

        if (medico != null)
        {
            medico.Estado = "I";
            medico.FechaSalida = DateTime.Now.ToString("yyyy-MM-dd");
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Medico>> GetAllAsync()
    {
        return await _context.Set<Medico>().ToListAsync();

        //Para que no se muestren lo médicos con el estado "I" (Inactivo)
        //return await _context.Medicos
        //.Where(m => m.Estado == "A")
        //.ToListAsync();
    }

    public async Task<IEnumerable<Medico>> GetMedicosActivo()
    {
        return await _context.Medicos
            .Where(m => m.Estado == "A")
            .ToListAsync();
    }

    public async Task<Medico> GetByIdAsync(string id)
    {
        return await _context.Set<Medico>().FindAsync(id);
    }

    public async Task<Medico> InsertAsync(Medico medico)
    {
        await _context.Set<Medico>().AddAsync(medico);

        var especialidadGeneral = await _context.Set<Especialidad>().FirstOrDefaultAsync(e => e.Nombre == "Medicina General");
        if (especialidadGeneral != null)
        {
            var medicoEspecialidad = new MedicoEspecialidad
            {
                MedicoNumeroDocumento = medico.NumeroDocumento,
                EspecialidadId = especialidadGeneral.Id
            };
            await _context.Set<MedicoEspecialidad>().AddAsync(medicoEspecialidad);
        }

        await _context.SaveChangesAsync();
        return medico;
    }

    public async Task<Medico> UpdateAsync(Medico medico)
    {
        var existingMedico = await _context.Set<Medico>().FindAsync(medico.NumeroDocumento);
        if (existingMedico != null)
        {
            _context.Entry(existingMedico).CurrentValues.SetValues(medico);
            await _context.SaveChangesAsync();
        }
        return existingMedico;
    }

    public async Task ActivarAsync(string id)
    {
        var medico = await _context.Medicos
            .FirstOrDefaultAsync(u => u.NumeroDocumento == id);

        if (medico != null)
        {
            medico.Estado = "A";
            medico.FechaSalida = null; // Opcional: limpiar la fecha de salida
            await _context.SaveChangesAsync();
        }
    }

    // Método corregido para obtener las especialidades de un médico
    public async Task<IEnumerable<MedicoEspecialidadUpdateDto2>> GetMedicoEspecialidad(string id)
    {
        // Realizar un join entre MedicoEspecialidad y Especialidad para obtener los detalles completos
        return await _context.Set<MedicoEspecialidad>()
            .Where(m => m.MedicoNumeroDocumento == id)
            .Join(
                _context.Set<Especialidad>(),
                me => me.EspecialidadId,
                e => e.Id,
                (me, e) => new MedicoEspecialidadUpdateDto2
                {
                    MedicoNumeroDocumento = me.MedicoNumeroDocumento,
                    EspecialidadId = me.EspecialidadId,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    Estado = e.Estado
                })
            .ToListAsync();
    }
}

