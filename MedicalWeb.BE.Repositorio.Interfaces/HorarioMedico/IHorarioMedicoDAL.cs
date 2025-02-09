﻿using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IHorarioMedicoDAL
{
    Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico);
    Task<HorarioMedico> DeleteHorarioMedicoAsync(int id);
    Task<IEnumerable<object>> GetHorarioMedicoAsync();
    Task<IEnumerable<object>> GetHorarioMedicoIdentificacionAsync(int Identificacion);
    Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico);
    Task<IEnumerable<object>> GetHorariosPorDiaYHoraAsync(string medicoId, int dia, int hora);
}