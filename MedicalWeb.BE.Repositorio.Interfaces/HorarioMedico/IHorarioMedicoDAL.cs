using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IHorarioMedicoDAL
{
    Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico);
    Task<HorarioMedico> DeleteHorarioMedicoAsync(int id);
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoAsync();
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int identificacion);
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionPacienteAsync(int identificacion);
    Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico);
    Task UpdateSalaIdAsync(int id, string salaId);
    Task UpdateEstadoHorarioId (int id, int estadoHorarioId);
    Task<IEnumerable<HorarioMedicoDTO>> GetCitasByPacienteAndDateRangeAsync(string pacienteId, DateTime fechaInicio, DateTime fechaFin);
}