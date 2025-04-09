using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio
{
    public class MedicoEspecialidadDAL : IMedicoEspecialidadDAL
    {
        private readonly MedicalWebDbContext _context;

        public MedicoEspecialidadDAL(MedicalWebDbContext context)
        {
            _context = context;
        }

        public async Task<MedicoEspecialidad> InsertAsync(MedicoEspecialidad medicoEspecialidad)
        {
            var existingAssignment = await _context.MedicoEspecialidades
                .FirstOrDefaultAsync(me => me.MedicoNumeroDocumento == medicoEspecialidad.MedicoNumeroDocumento &&
                                           me.EspecialidadId == medicoEspecialidad.EspecialidadId);

            if (existingAssignment != null)
            {
                throw new InvalidOperationException("El médico ya tiene esta especialidad asignada.");
            }

            _context.MedicoEspecialidades.Add(medicoEspecialidad);
            await _context.SaveChangesAsync();
            return medicoEspecialidad;
        }

        public async Task DeleteAsync(string medicoNumeroDocumento, int especialidadId)
        {
            var medicoEspecialidad = await _context.MedicoEspecialidades
                .FirstOrDefaultAsync(me => me.MedicoNumeroDocumento == medicoNumeroDocumento && me.EspecialidadId == especialidadId);

            if (medicoEspecialidad != null)
            {
                _context.MedicoEspecialidades.Remove(medicoEspecialidad);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(string especialidadNombre)
        {
            var especialidad = await _context.Especialidades
                                              .FirstOrDefaultAsync(e => e.Nombre == especialidadNombre);

            if (especialidad == null)
            {
                return null;
            }

            var medicos = await _context.MedicoEspecialidades
                                         .Where(me => me.EspecialidadId == especialidad.Id)
                                         .Select(me => me.Medico) // Seleccionamos los médicos asociados
                                         .ToListAsync();

            return medicos;
        }

        public async Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesActivasAsync()
        {
            return await _context.Especialidades
                .Where(e => e.Estado == "Activo")
                .ToListAsync();
        }

        public async Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesInactivasAsync()
        {
            return await _context.Especialidades
                .Where(e => e.Estado == "Inactivo")
                .ToListAsync();
        }

        public async Task<MedicoEspecialidad> GetByMedicoAndEspecialidadAsync(string medicoNumeroDocumento, int especialidadId)
        {
            var medicoEspecialidad = await _context.MedicoEspecialidades
                .FirstOrDefaultAsync(me => me.MedicoNumeroDocumento == medicoNumeroDocumento && me.EspecialidadId == especialidadId);

            if (medicoEspecialidad == null)
            {
                return null;
            }

            var asignacionDto = new MedicoEspecialidad
            {
                MedicoNumeroDocumento = medicoEspecialidad.MedicoNumeroDocumento,
                EspecialidadId = medicoEspecialidad.EspecialidadId
            };

            return asignacionDto;
        }

        public async Task<MedicoEspecialidad> UpdateAsync(string medicoNumeroDocumento, int especialidadId, int especialidadIdNueva)
        {
            var existingMedicoEspecialidad = await _context.MedicoEspecialidades
                .FirstOrDefaultAsync(me => me.MedicoNumeroDocumento == medicoNumeroDocumento &&
                                           me.EspecialidadId == especialidadId);

            if (existingMedicoEspecialidad == null)
            {
                throw new InvalidOperationException("La asignación de médico y especialidad no existe.");
            }

            var duplicateMedicoEspecialidad = await _context.MedicoEspecialidades
                .FirstOrDefaultAsync(me => me.MedicoNumeroDocumento == medicoNumeroDocumento &&
                                           me.EspecialidadId == especialidadIdNueva);

            if (duplicateMedicoEspecialidad != null)
            {
                throw new InvalidOperationException("El médico ya tiene esta especialidad asignada.");
            }

            var nuevaEspecialidad = await _context.Especialidades
                .FirstOrDefaultAsync(e => e.Id == especialidadIdNueva);

            if (nuevaEspecialidad == null)
            {
                throw new InvalidOperationException("La nueva especialidad no existe.");
            }

            existingMedicoEspecialidad.EspecialidadId = especialidadIdNueva;

            await _context.SaveChangesAsync();
            return existingMedicoEspecialidad;
        }

        public async Task<IEnumerable<MedicoEspecialidad>> GetMedicosEspecialidadesAsync()
        {
            return await _context.MedicoEspecialidades
                .Include(me => me.Medico)
                .Include(me => me.Especialidad)
                .ToListAsync();
        }

        // Implementación del nuevo método para actualizar todas las especialidades de un médico
        public async Task UpdateMedicoEspecialidadesAsync(string medicoNumeroDocumento, List<int> especialidadesIds)
        {
            // Obtener las especialidades actuales del médico
            var especialidadesActuales = await _context.MedicoEspecialidades
                .Where(me => me.MedicoNumeroDocumento == medicoNumeroDocumento)
                .ToListAsync();

            // Identificar especialidades a eliminar (las que están en la BD pero no en la lista nueva)
            var especialidadesAEliminar = especialidadesActuales
                .Where(me => !especialidadesIds.Contains(me.EspecialidadId))
                .ToList();

            // Identificar especialidades a agregar (las que están en la lista nueva pero no en la BD)
            var especialidadesIdsActuales = especialidadesActuales.Select(me => me.EspecialidadId).ToList();
            var especialidadesAAgregar = especialidadesIds
                .Where(id => !especialidadesIdsActuales.Contains(id))
                .ToList();

            // Eliminar las especialidades que ya no están seleccionadas
            foreach (var especialidad in especialidadesAEliminar)
            {
                _context.MedicoEspecialidades.Remove(especialidad);
            }

            // Agregar las nuevas especialidades seleccionadas
            foreach (var especialidadId in especialidadesAAgregar)
            {
                // Verificar que la especialidad existe
                var especialidadExiste = await _context.Especialidades.AnyAsync(e => e.Id == especialidadId);
                if (especialidadExiste)
                {
                    _context.MedicoEspecialidades.Add(new MedicoEspecialidad
                    {
                        MedicoNumeroDocumento = medicoNumeroDocumento,
                        EspecialidadId = especialidadId
                    });
                }
            }

            // Guardar todos los cambios en una sola transacción
            await _context.SaveChangesAsync();
        }

        // Implementación del nuevo método para obtener las especialidades de un médico
        public async Task<IEnumerable<MedicoEspecialidad>> GetEspecialidadesByMedicoAsync(string medicoNumeroDocumento)
        {
            return await _context.MedicoEspecialidades
                .Where(me => me.MedicoNumeroDocumento == medicoNumeroDocumento)
                .Include(me => me.Especialidad)
                .ToListAsync();
        }
    }
}

