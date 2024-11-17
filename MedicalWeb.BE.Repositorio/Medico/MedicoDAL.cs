using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
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
        var medico = await _context.Set<Medico>().FindAsync(id);
        if (medico != null)
        {
            medico.Estado = "I";
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Medico>> GetAllAsync()
    {
        return await _context.Set<Medico>().ToListAsync();
    }

    public async Task<Medico> GetByIdAsync(string id)
    {
        return await _context.Set<Medico>().FindAsync(id);
    }

    public async Task<Medico> InsertAsync(Medico medico)
    {
        await _context.Set<Medico>().AddAsync(medico);

        string nombreUsuario;
        if (string.IsNullOrEmpty(medico.SegundoNombre))
        {
            nombreUsuario = $"{medico.PrimerNombre.Substring(0, 2).ToLower()}{medico.PrimerApellido.ToLower()}";
        }
        else
        {
            nombreUsuario = $"{medico.PrimerNombre[0]}{medico.SegundoNombre[0]}{medico.PrimerApellido}".ToUpper();
        }

        // Validar que el nombre de usuario no exista y agregar un contador si es necesario
        int contador = 1;
        string nombreUsuarioOriginal = nombreUsuario;
        while (await _context.Set<Usuario>().AnyAsync(u => u.NombreUsuario == nombreUsuario))
        {
            nombreUsuario = $"{nombreUsuarioOriginal}{contador}";
            contador++;
        }

        // NOTE: Por el momento la contraseña se guarda de tipo string sin encriptación
        // A futuro se debe encriptar la contraseña antes de guardarla.

        // Crear la entidad de usuario asociada al médico
        var usuario = new Usuario
        {
            Identificacion = medico.NumeroDocumento,
            NombreUsuario = nombreUsuario,
            Password = "Medical2024" 
        };
        await _context.Set<Usuario>().AddAsync(usuario);

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
}
