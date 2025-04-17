using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Infraestructure.Persitence;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

    public async Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico)
    {
        return await _horarioMedicoDAL.UpdateHorarioMedicoAsync(horarioMedico);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoAsync()
    {
        return await _horarioMedicoDAL.GetHorarioMedicoAsync();
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int identificacion)
    {
        return await _horarioMedicoDAL.GetHorarioMedicoIdentificacionAsync(identificacion);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionPacienteAsync(int identificacion)
    {
        return await _horarioMedicoDAL.GetHorarioMedicoIdentificacionPacienteAsync(identificacion);
    }

    public async Task UpdateSalaIdAsync(int id, string salaId)
    {
        await _horarioMedicoDAL.UpdateSalaIdAsync(id, salaId);
    }

    public async Task UpdateEstadoHorarioId(int id, int EstadoHorarioId)
    {
        await _horarioMedicoDAL.UpdateEstadoHorarioId(id, EstadoHorarioId);
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetCitasByPacienteAndDateRangeAsync(string pacienteId, string fechaInicio, string fechaFin)
    {
        // Convertir las fechas de string a DateTime
        if (!DateTime.TryParseExact(fechaInicio, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaInicioDate))
        {
            throw new ArgumentException("Formato de fecha de inicio inválido. Use dd-MM-yyyy");
        }

        if (!DateTime.TryParseExact(fechaFin, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaFinDate))
        {
            throw new ArgumentException("Formato de fecha de fin inválido. Use dd-MM-yyyy");
        }

        // Obtener las citas del paciente en el rango de fechas
        var citas = await _horarioMedicoDAL.GetCitasByPacienteAndDateRangeAsync(pacienteId, fechaInicioDate, fechaFinDate);
        return citas;
    }

}