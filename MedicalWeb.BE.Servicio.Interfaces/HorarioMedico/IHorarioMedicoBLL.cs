using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IHorarioMedicoBLL
{
    Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico);
    Task<HorarioMedico> DeleteHorarioMedicoAsync(int id);
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoAsync();
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int Identificacion);
    Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico);
    Task UpdateSalaIdAsync(int id, string salaId);
    Task UpdateEstadoHorarioId(int id, int EstadoHorarioId);
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionPacienteAsync(int id);
    Task<IEnumerable<HorarioMedicoDTO>> GetCitasByPacienteAndDateRangeAsync(string pacienteId, string fechaInicio, string fechaFin);
}