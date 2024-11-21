using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Core;
namespace MedicalWeb.BE.Servicio;

public class HorarioMedicoBLL : IHorarioMedicoBLL
{
    private readonly IHorarioMedicoDAL _horarioMedicoDAL;

    public HorarioMedicoBLL(IHorarioMedicoDAL horarioMedicoDAL)
    {
        _horarioMedicoDAL = horarioMedicoDAL;
    }

    public async Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico)
    {
        return await _horarioMedicoDAL.CreateHorarioMedicoIdAsync(horarioMedico);
    }

    public async Task<HorarioMedico> DeleteHorarioMedicoAsync(int Identificacion)
    {
        return await _horarioMedicoDAL.DeleteHorarioMedicoAsync(Identificacion);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoAsync()
    {
        var horarios = await _horarioMedicoDAL.GetHorarioMedicoAsync();
        return MapToDTO(horarios);
    }

    public static HorarioMedicoDTO MapToDTO(HorarioMedico horario)
    {
        return new HorarioMedicoDTO
        {
            Id = horario.Id,
            IdentificacionCliente = horario.IdentificacionCliente,
            NumeroDocumento = horario.NumeroDocumento,
            Dia = Dias.GetById(horario.DiaID).Code,
            Hora = HorasMedicas.GetById(horario.HoraID).Code,
            Estado = EstadoHorarioMedico.GetById(horario.EstadoHorarioID).Code,
            Fecha = horario.Fecha
        };
    }

    public static IEnumerable<HorarioMedicoDTO> MapToDTO(IEnumerable<HorarioMedico> horarios)
    {
        return horarios.Select(MapToDTO);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int id)
    {
        var horarios = await _horarioMedicoDAL.GetHorarioMedicoIdentificacionAsync(id);
        return MapToDTO(horarios);
    }

    public async Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico)
    {
        return await _horarioMedicoDAL.UpdateHorarioMedicoAsync(horarioMedico);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> ConsultarHorariosPorDiaYHoraAsync(string medicoId, int dia, int hora)
    {
        var horarios = await _horarioMedicoDAL.GetHorariosPorDiaYHoraAsync(medicoId, dia, hora);
        return MapToDTO(horarios);
    }
}