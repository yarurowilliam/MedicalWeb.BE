using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalWeb.BE.Servicio.Interfaces;

namespace MedicalWeb.BE.Servicio
{
    public class MedicoEspecialidadBLL : IMedicoEspecialidadBLL
    {
        private readonly IMedicoEspecialidadDAL _medicoEspecialidadDAL;

        public MedicoEspecialidadBLL(IMedicoEspecialidadDAL medicoEspecialidadDAL)
        {
            _medicoEspecialidadDAL = medicoEspecialidadDAL;
        }

        public async Task<MedicoEspecialidad> InsertAsync(MedicoEspecialidad medicoEspecialidad)
        {
            return await _medicoEspecialidadDAL.InsertAsync(medicoEspecialidad);
        }

        public async Task DeleteAsync(string medicoNumeroDocumento, int especialidadId)
        {
            await _medicoEspecialidadDAL.DeleteAsync(medicoNumeroDocumento, especialidadId);
        }

        public async Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(string especialidadNombre)
        {
            return await _medicoEspecialidadDAL.GetMedicosByEspecialidadAsync(especialidadNombre);
        }

        public async Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesActivasAsync()
        {
            return await _medicoEspecialidadDAL.GetMedicosEspecialidadesActivasAsync();
        }

        public async Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesInactivasAsync()
        {
            return await _medicoEspecialidadDAL.GetMedicosEspecialidadesInactivasAsync();
        }

        public async Task<MedicoEspecialidad> GetByMedicoAndEspecialidadAsync(string medicoNumeroDocumento, int especialidadId)
        {
            return await _medicoEspecialidadDAL.GetByMedicoAndEspecialidadAsync(medicoNumeroDocumento, especialidadId);
        }

        public async Task<MedicoEspecialidad> UpdateAsync(string medicoNumeroDocumento, int especialidadId, int especialidadIdNueva)
        {
            return await _medicoEspecialidadDAL.UpdateAsync(medicoNumeroDocumento, especialidadId, especialidadIdNueva);
        }

        public async Task<IEnumerable<MedicoEspecialidad>> GetMedicosEspecialidadesAsync()
        {
            return await _medicoEspecialidadDAL.GetMedicosEspecialidadesAsync();
        }

        // Implementación del nuevo método para actualizar todas las especialidades de un médico
        public async Task UpdateMedicoEspecialidadesAsync(string medicoNumeroDocumento, List<int> especialidadesIds)
        {
            await _medicoEspecialidadDAL.UpdateMedicoEspecialidadesAsync(medicoNumeroDocumento, especialidadesIds);
        }

        // Implementación del nuevo método para obtener las especialidades de un médico
        public async Task<IEnumerable<MedicoEspecialidad>> GetEspecialidadesByMedicoAsync(string medicoNumeroDocumento)
        {
            return await _medicoEspecialidadDAL.GetEspecialidadesByMedicoAsync(medicoNumeroDocumento);
        }
    }
}

