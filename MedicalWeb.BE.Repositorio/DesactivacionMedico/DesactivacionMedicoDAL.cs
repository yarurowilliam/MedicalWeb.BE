using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio
{
    public class DesactivacionMedicoDAL : IDesactivacionMedicoDAL
    {
        private readonly MedicalWebDbContext _context;

        public DesactivacionMedicoDAL(MedicalWebDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesAsync()
        {
            return await _context.DesactivacionMedico.ToListAsync();
        }

        public async Task<DesactivacionMedico> GetDesactivacionByIdAsync(int id)
        {
            return await _context.DesactivacionMedico.FindAsync(id);
        }

        public async Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesByMedicoAsync(string numeroDocumento)
        {
            return await _context.DesactivacionMedico
                .Where(d => d.NumeroDocumento == numeroDocumento)
                .ToListAsync();
        }

        public async Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesActivasByMedicoAsync(string numeroDocumento)
        {
            var fechaActual = DateTime.Now;

            return await _context.DesactivacionMedico
                .Where(d => d.NumeroDocumento == numeroDocumento &&
                           d.Estado == "A" &&
                           (d.FechaFin == null || d.FechaFin >= fechaActual) &&
                           d.FechaInicio <= fechaActual)
                .ToListAsync();
        }

        public async Task<DesactivacionMedico> CreateDesactivacionAsync(DesactivacionMedico desactivacion)
        {
            // Verificar si el médico existe
            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.NumeroDocumento == desactivacion.NumeroDocumento);
            if (medico == null)
            {
                throw new InvalidOperationException("El médico no existe");
            }

            // Establecer estado activo
            desactivacion.Estado = "A";

            _context.DesactivacionMedico.Add(desactivacion);
            await _context.SaveChangesAsync();

            return desactivacion;
        }

        public async Task<DesactivacionMedico> UpdateDesactivacionAsync(DesactivacionMedico desactivacion)
        {
            _context.Entry(desactivacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DesactivacionExistsAsync(desactivacion.Id))
                {
                    throw new InvalidOperationException($"No existe una desactivación con ID {desactivacion.Id}");
                }
                throw;
            }

            return desactivacion;
        }

        public async Task<bool> DeleteDesactivacionAsync(int id)
        {
            var desactivacion = await _context.DesactivacionMedico.FindAsync(id);
            if (desactivacion == null)
            {
                return false;
            }

            _context.DesactivacionMedico.Remove(desactivacion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DesactivarDesactivacionesByMedicoAsync(string numeroDocumento)
        {
            // Buscar desactivaciones activas para este médico
            var desactivacionesActivas = await _context.DesactivacionMedico
                .Where(d => d.NumeroDocumento == numeroDocumento && d.Estado == "A")
                .ToListAsync();

            if (!desactivacionesActivas.Any())
            {
                return false;
            }

            // Marcar todas las desactivaciones como inactivas
            foreach (var desactivacion in desactivacionesActivas)
            {
                desactivacion.Estado = "I";
                _context.Entry(desactivacion).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerificarYActualizarDesactivacionesVencidasAsync()
        {
            var fechaActual = DateTime.Now;

            // Buscar desactivaciones temporales que hayan vencido
            var desactivacionesVencidas = await _context.DesactivacionMedico
                .Where(d => d.Estado == "A" && d.FechaFin != null && d.FechaFin <= fechaActual)
                .ToListAsync();

            if (!desactivacionesVencidas.Any())
            {
                return false;
            }

            // Agrupar por médico para procesar cada médico una sola vez
            var medicoIds = desactivacionesVencidas.Select(d => d.NumeroDocumento).Distinct().ToList();

            foreach (var desactivacion in desactivacionesVencidas)
            {
                desactivacion.Estado = "I";
                _context.Entry(desactivacion).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            // Para cada médico, verificar si tiene otras desactivaciones activas
            foreach (var medicoId in medicoIds)
            {
                var tieneOtrasDesactivacionesActivas = await _context.DesactivacionMedico
                    .AnyAsync(d => d.NumeroDocumento == medicoId &&
                                  d.Estado == "A" &&
                                  (d.FechaFin == null || d.FechaFin > fechaActual) &&
                                  d.FechaInicio <= fechaActual);

                if (!tieneOtrasDesactivacionesActivas)
                {
                    // Activar el médico si no tiene otras desactivaciones activas
                    var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.NumeroDocumento == medicoId);
                    if (medico != null && medico.Estado == "I")
                    {
                        medico.Estado = "A";
                        _context.Entry(medico).State = EntityState.Modified;
                    }
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> DesactivacionExistsAsync(int id)
        {
            return await _context.DesactivacionMedico.AnyAsync(e => e.Id == id);
        }
    }
}