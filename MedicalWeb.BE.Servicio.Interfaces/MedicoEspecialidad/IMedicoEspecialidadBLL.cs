using MedicalWeb.BE.Transversales.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio.Interfaces
{
    public interface IMedicoEspecialidadBLL
    {
        Task<MedicoEspecialidad> InsertAsync(MedicoEspecialidad medicoEspecialidad);
        Task DeleteAsync(string medicoNumeroDocumento, int especialidadId);
        Task<IEnumerable<Medico>> GetMedicosByEspecialidadAsync(string especialidadNombre);
        Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesActivasAsync();
        Task<IEnumerable<Especialidad>> GetMedicosEspecialidadesInactivasAsync();
        Task<MedicoEspecialidad> GetByMedicoAndEspecialidadAsync(string medicoNumeroDocumento, int especialidadId);
        Task<MedicoEspecialidad> UpdateAsync(string medicoNumeroDocumento, int especialidadId, int especialidadIdNueva);
        Task<IEnumerable<MedicoEspecialidad>> GetMedicosEspecialidadesAsync();

        // Nuevos métodos
        Task UpdateMedicoEspecialidadesAsync(string medicoNumeroDocumento, List<int> especialidadesIds);
        Task<IEnumerable<MedicoEspecialidad>> GetEspecialidadesByMedicoAsync(string medicoNumeroDocumento);
    }
}

