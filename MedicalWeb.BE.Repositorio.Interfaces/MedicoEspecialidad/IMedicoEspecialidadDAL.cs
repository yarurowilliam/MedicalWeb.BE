using MedicalWeb.BE.Transversales.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Repositorio.Interfaces
{
    public interface IMedicoEspecialidadDAL
    {
        Task<MedicoEspecialidad> InsertAsync(MedicoEspecialidad medicoEspecialidad);
        Task DeleteAsync(string medicoNumeroDocumento, int especialidadId);
        Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(string especialidadNombre);
        Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesActivasAsync();
        Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesInactivasAsync();
        Task<MedicoEspecialidad> GetByMedicoAndEspecialidadAsync(string medicoNumeroDocumento, int especialidadId);
        Task<MedicoEspecialidad> UpdateAsync(string medicoNumeroDocumento, int especialidadId, int especialidadIdNueva);
        Task<IEnumerable<MedicoEspecialidad>> GetMedicosEspecialidadesAsync();
    }
}