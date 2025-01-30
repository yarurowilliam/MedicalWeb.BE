using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
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

        return horarios.Select(h => new HorarioMedicoDTO
        {
            Id = (int)h.GetType().GetProperty("Id").GetValue(h),
            IdentificacionCliente = (string)h.GetType().GetProperty("IdentificacionPaciente").GetValue(h),
            NombrePaciente = (string)h.GetType().GetProperty("NombrePaciente").GetValue(h),
            NumeroDocumento = (string)h.GetType().GetProperty("NumeroDocumentoMedico").GetValue(h),
            NombreMedico = (string)h.GetType().GetProperty("NombreMedico").GetValue(h),
            Dia = Dias.GetById((int)h.GetType().GetProperty("Dia").GetValue(h)).Code,
            Hora = HorasMedicas.GetById((int)h.GetType().GetProperty("Hora").GetValue(h)).Code,
            Estado = EstadoHorarioMedico.GetById(int.Parse((string)h.GetType().GetProperty("Estado").GetValue(h))).Code,
            Fecha = (DateOnly)h.GetType().GetProperty("Fecha").GetValue(h)
        });
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int id)
    {
        var horarios = await _horarioMedicoDAL.GetHorarioMedicoIdentificacionAsync(id);
        return horarios.Select(h => new HorarioMedicoDTO
        {
            Id = (int)h.GetType().GetProperty("Id").GetValue(h),
            IdentificacionCliente = (string)h.GetType().GetProperty("IdentificacionPaciente").GetValue(h),
            NombrePaciente = (string)h.GetType().GetProperty("NombrePaciente").GetValue(h),
            NumeroDocumento = (string)h.GetType().GetProperty("NumeroDocumentoMedico").GetValue(h),
            NombreMedico = (string)h.GetType().GetProperty("NombreMedico").GetValue(h),
            Dia = Dias.GetById((int)h.GetType().GetProperty("Dia").GetValue(h)).Code,
            Hora = HorasMedicas.GetById((int)h.GetType().GetProperty("Hora").GetValue(h)).Code,
            Estado = EstadoHorarioMedico.GetById(int.Parse((string)h.GetType().GetProperty("Estado").GetValue(h))).Code,
            Fecha = (DateOnly)h.GetType().GetProperty("Fecha").GetValue(h)
        });
    }

    public async Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico)
    {
        return await _horarioMedicoDAL.UpdateHorarioMedicoAsync(horarioMedico);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> ConsultarHorariosPorDiaYHoraAsync(string medicoId, int dia, int hora)
    {
        var horarios = await  _horarioMedicoDAL.GetHorariosPorDiaYHoraAsync(medicoId, dia, hora);
        return horarios.Select(h => new HorarioMedicoDTO
        {
            Id = (int)h.GetType().GetProperty("Id").GetValue(h),
            IdentificacionCliente = (string)h.GetType().GetProperty("IdentificacionPaciente").GetValue(h),
            NombrePaciente = (string)h.GetType().GetProperty("NombrePaciente").GetValue(h),
            NumeroDocumento = (string)h.GetType().GetProperty("NumeroDocumentoMedico").GetValue(h),
            NombreMedico = (string)h.GetType().GetProperty("NombreMedico").GetValue(h),
            Dia = Dias.GetById((int)h.GetType().GetProperty("Dia").GetValue(h)).Code,
            Hora = HorasMedicas.GetById((int)h.GetType().GetProperty("Hora").GetValue(h)).Code,
            Estado = EstadoHorarioMedico.GetById(int.Parse((string)h.GetType().GetProperty("Estado").GetValue(h))).Code,
            Fecha = (DateOnly)h.GetType().GetProperty("Fecha").GetValue(h)
        });
    }
}