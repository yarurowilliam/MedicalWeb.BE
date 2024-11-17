using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IHorarioMedicoBLL
{
    Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico);
    Task<HorarioMedico> DeleteHorarioMedicoAsync(int id);
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoAsync();
    Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int Identificacion);
    Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico);
    Task<IEnumerable<HorarioMedicoDTO>> ConsultarHorariosPorDiaYHoraAsync(string medicoId, int dia, int hora);
}