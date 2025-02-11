using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Infraestructure.Persitence;
using Microsoft.EntityFrameworkCore;
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

}