using MedicalWeb.BE.BLL.Interfaces;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.BLL
{
    public class DesactivacionMedicoBLL : IDesactivacionMedicoBLL
    {
        private readonly IDesactivacionMedicoDAL _desactivacionMedicoDAL;
        private readonly IMedicoDAL _medicoDAL;

        public DesactivacionMedicoBLL(IDesactivacionMedicoDAL desactivacionMedicoDAL, IMedicoDAL medicoDAL)
        {
            _desactivacionMedicoDAL = desactivacionMedicoDAL;
            _medicoDAL = medicoDAL;
        }

        public async Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesAsync()
        {
            return await _desactivacionMedicoDAL.GetDesactivacionesAsync();
        }

        public async Task<DesactivacionMedico> GetDesactivacionByIdAsync(int id)
        {
            return await _desactivacionMedicoDAL.GetDesactivacionByIdAsync(id);
        }

        public async Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesByMedicoAsync(string numeroDocumento)
        {
            return await _desactivacionMedicoDAL.GetDesactivacionesByMedicoAsync(numeroDocumento);
        }

        public async Task<IEnumerable<DesactivacionMedico>> GetDesactivacionesActivasByMedicoAsync(string numeroDocumento)
        {
            return await _desactivacionMedicoDAL.GetDesactivacionesActivasByMedicoAsync(numeroDocumento);
        }

        public async Task<DesactivacionMedico> CreateDesactivacionAsync(DesactivacionMedico desactivacion)
        {
            // Validaciones adicionales
            if (string.IsNullOrEmpty(desactivacion.NumeroDocumento))
            {
                throw new ArgumentException("El número de documento del médico es requerido");
            }

            if (string.IsNullOrEmpty(desactivacion.Motivo))
            {
                throw new ArgumentException("El motivo de desactivación es requerido");
            }

            if (desactivacion.FechaInicio < DateTime.Now.Date)
            {
                throw new ArgumentException("La fecha de inicio no puede ser anterior a la fecha actual");
            }

            if (desactivacion.FechaFin.HasValue && desactivacion.FechaFin.Value <= desactivacion.FechaInicio)
            {
                throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio");
            }

            var result = await _desactivacionMedicoDAL.CreateDesactivacionAsync(desactivacion);

            // Desactivar el médico
            await _medicoDAL.DeleteAsync(desactivacion.NumeroDocumento);

            return result;
        }

        public async Task<DesactivacionMedico> UpdateDesactivacionAsync(DesactivacionMedico desactivacion)
        {
            // Validaciones
            if (desactivacion.Id <= 0)
            {
                throw new ArgumentException("ID de desactivación inválido");
            }

            if (string.IsNullOrEmpty(desactivacion.Motivo))
            {
                throw new ArgumentException("El motivo de desactivación es requerido");
            }

            if (desactivacion.FechaFin.HasValue && desactivacion.FechaFin.Value <= desactivacion.FechaInicio)
            {
                throw new ArgumentException("La fecha de fin debe ser posterior a la fecha de inicio");
            }

            return await _desactivacionMedicoDAL.UpdateDesactivacionAsync(desactivacion);
        }

        public async Task<bool> DeleteDesactivacionAsync(int id)
        {
            return await _desactivacionMedicoDAL.DeleteDesactivacionAsync(id);
        }

        public async Task<bool> DesactivarDesactivacionesByMedicoAsync(string numeroDocumento)
        {
            var result = await _desactivacionMedicoDAL.DesactivarDesactivacionesByMedicoAsync(numeroDocumento);

            // Si se desactivaron todas las desactivaciones, activar el médico
            if (result)
            {
                await _medicoDAL.ActivarAsync(numeroDocumento);
            }

            return result;
        }

        public async Task<bool> VerificarYActualizarDesactivacionesVencidasAsync()
        {
            return await _desactivacionMedicoDAL.VerificarYActualizarDesactivacionesVencidasAsync();
        }
    }
}