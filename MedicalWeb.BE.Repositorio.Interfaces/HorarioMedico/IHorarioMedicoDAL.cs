using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IHorarioMedicoDAL
{
    Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico);
    Task<HorarioMedico> DeleteHorarioMedicoAsync(int id);
    Task<IEnumerable<HorarioMedico>> GetHorarioMedicoAsync();
    Task<IEnumerable<HorarioMedico>> GetHorarioMedicoIdentificacionAsync(int Identificacion);
    Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico);
    Task<IEnumerable<HorarioMedico>> GetHorariosPorDiaYHoraAsync(string medicoId, int dia, int hora);
}