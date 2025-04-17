using MedicalWeb.BE.Transversales.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.BLL.Interfaces
{
    public interface IDesactivacionMedicoBLL
    {
        Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesAsync();
        Task<DesactivacionMedico> GetDesactivacionByIdAsync(int id);
        Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesByMedicoAsync(string numeroDocumento);
        Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesActivasByMedicoAsync(string numeroDocumento);
        Task<DesactivacionMedico> CreateDesactivacionAsync(DesactivacionMedico desactivacion);
        Task<DesactivacionMedico> UpdateDesactivacionAsync(DesactivacionMedico desactivacion);
        Task<bool> DeleteDesactivacionAsync(int id);
        Task<bool> DesactivarDesactivacionesByMedicoAsync(string numeroDocumento);
        Task<bool> VerificarYActualizarDesactivacionesVencidasAsync();
    }
}