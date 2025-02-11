﻿using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
namespace MedicalWeb.BE.Repositorio;

public class HorarioMedicoDAL : IHorarioMedicoDAL
{
    private readonly MedicalWebDbContext _context;
   

    public HorarioMedicoDAL(MedicalWebDbContext context)
    {
        
        _context = context;
    }

    public async Task<HorarioMedico> CreateHorarioMedicoIdAsync(HorarioMedico horarioMedico)
    {
        var diaDeLaSemana = Dias.GetByDayOfWeek(horarioMedico.Fecha.DayOfWeek);
        horarioMedico.DiaID = diaDeLaSemana.DiaID;

        if (!await _context.HorasMedicas.AnyAsync(h => h.HoraMedicaID == horarioMedico.HoraID))
            throw new InvalidOperationException("La hora no es aceptada.");

        if (!await _context.EstadoHorarioMedicos.AnyAsync(e => e.EstadoHorarioID == horarioMedico.EstadoHorarioID))
            throw new InvalidOperationException("El estado del horario no es válido.");

        if (!await _context.Medicos.AnyAsync(m => m.NumeroDocumento == horarioMedico.NumeroDocumento))
            throw new InvalidOperationException("El médico no está registrado.");

        if (await _context.HorarioMedico.AnyAsync(h =>
            h.NumeroDocumento == horarioMedico.NumeroDocumento &&
            h.DiaID == horarioMedico.DiaID &&
            h.HoraID == horarioMedico.HoraID &&
            h.Fecha == horarioMedico.Fecha))
            throw new InvalidOperationException("La hora ya está asignada.");

        horarioMedico.EstadoHorarioID = 1;

        _context.HorarioMedico.Add(horarioMedico);
        await _context.SaveChangesAsync();
        return horarioMedico;
    }

    public async Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico)
    {
        var diaDeLaSemana = Dias.GetByDayOfWeek(horarioMedico.Fecha.DayOfWeek);
        horarioMedico.DiaID = diaDeLaSemana.DiaID;

        if (!await _context.Dias.AnyAsync(d => d.DiaID == horarioMedico.DiaID))
            throw new InvalidOperationException("El día no existe.");

        if (!await _context.HorasMedicas.AnyAsync(h => h.HoraMedicaID == horarioMedico.HoraID))
            throw new InvalidOperationException("La hora no es aceptada.");

        if (!await _context.EstadoHorarioMedicos.AnyAsync(e => e.EstadoHorarioID == horarioMedico.EstadoHorarioID))
            throw new InvalidOperationException("El estado del horario no es válido.");

        if (!await _context.Medicos.AnyAsync(m => m.NumeroDocumento == horarioMedico.NumeroDocumento))
            throw new InvalidOperationException("El médico no está registrado.");

        if (await _context.HorarioMedico.AnyAsync(h =>
            h.NumeroDocumento == horarioMedico.NumeroDocumento &&
            h.DiaID == horarioMedico.DiaID &&
            h.HoraID == horarioMedico.HoraID &&
            h.Fecha == horarioMedico.Fecha &&
            h.Id != horarioMedico.Id))
            throw new InvalidOperationException("La hora ya está asignada.");

        _context.HorarioMedico.Update(horarioMedico);
        await _context.SaveChangesAsync();
        return horarioMedico;
    }

    public async Task<HorarioMedico> DeleteHorarioMedicoAsync(int id)
    {
        var horarioMedico = await _context.HorarioMedico.FindAsync(id);
        if (horarioMedico == null)
            return null;

        _context.HorarioMedico.Remove(horarioMedico);
        await _context.SaveChangesAsync();
        return horarioMedico;
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoAsync()
    {
        return await (from h in _context.HorarioMedico
                      join m in _context.Medicos on h.NumeroDocumento equals m.NumeroDocumento
                      join p in _context.Pacientes on h.IdentificacionCliente equals p.NumeroDocumento
                      select new HorarioMedicoDTO
                      {
                          Id = h.Id,
                          NumeroDocumento = m.NumeroDocumento,
                          NombreMedico = $"{m.PrimerNombre} {m.SegundoNombre} {m.PrimerApellido}".Trim(),
                          IdentificacionCliente = p.NumeroDocumento,
                          NombrePaciente = $"{p.PrimerNombre} {p.SegundoNombre} {p.PrimerApellido}".Trim(),
                          Dia = Dias.GetById(h.DiaID).Code,
                          Hora = HorasMedicas.GetById(h.HoraID).Code,
                          Estado = EstadoHorarioMedico.GetById(h.EstadoHorarioID).Code,
                          Fecha = h.Fecha,
                          SalaId = h.SalaId
                      }).ToListAsync();
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionAsync(int identificacion)
    {
        return await (from h in _context.HorarioMedico
                      join m in _context.Medicos on h.NumeroDocumento equals m.NumeroDocumento
                      join p in _context.Pacientes on h.IdentificacionCliente equals p.NumeroDocumento
                      where h.NumeroDocumento == identificacion.ToString()
                      select new HorarioMedicoDTO
                      {
                          Id = h.Id,
                          NumeroDocumento = m.NumeroDocumento,
                          NombreMedico = $"{m.PrimerNombre} {m.SegundoNombre} {m.PrimerApellido}".Trim(),
                          IdentificacionCliente = p.NumeroDocumento,
                          NombrePaciente = $"{p.PrimerNombre} {p.SegundoNombre} {p.PrimerApellido}".Trim(),
                          Dia = Dias.GetById(h.DiaID).Code,
                          Hora = HorasMedicas.GetById(h.HoraID).Code,
                          Fecha = h.Fecha,
                          Estado = EstadoHorarioMedico.GetById(h.EstadoHorarioID).Code,
                          SalaId = h.SalaId
                      }).ToListAsync();
    }

    public async Task<IEnumerable<HorarioMedicoDTO>> GetHorarioMedicoIdentificacionPacienteAsync(int identificacion)
    {
        return await (from h in _context.HorarioMedico
                      join m in _context.Medicos on h.NumeroDocumento equals m.NumeroDocumento
                      join p in _context.Pacientes on h.IdentificacionCliente equals p.NumeroDocumento
                      where h.IdentificacionCliente == identificacion.ToString() || h.Id == identificacion
                      select new HorarioMedicoDTO
                      {
                          Id = h.Id,
                          NumeroDocumento = m.NumeroDocumento,
                          NombreMedico = $"{m.PrimerNombre} {m.SegundoNombre} {m.PrimerApellido}".Trim(),
                          IdentificacionCliente = p.NumeroDocumento,
                          NombrePaciente = $"{p.PrimerNombre} {p.SegundoNombre} {p.PrimerApellido}".Trim(),
                          Dia = Dias.GetById(h.DiaID).Code,
                          Hora = HorasMedicas.GetById(h.HoraID).Code,
                          Estado = EstadoHorarioMedico.GetById(h.EstadoHorarioID).Code,
                          Fecha = h.Fecha,
                          SalaId = h.SalaId
                      }).ToListAsync();
    }


    public async Task UpdateSalaIdAsync(int id, string salaId)
    {
        //var horario = await _context.HorarioMedico.FindAsync(id);
        var horario = await _context.HorarioMedico
                                             .FirstOrDefaultAsync(e => e.Id == id);
        if (horario == null)
        {
            throw new InvalidOperationException("El horario médico no existe.");
        }

        horario.SalaId = salaId;
        _context.Entry(horario).Property(h => h.SalaId).IsModified = true;
        await _context.SaveChangesAsync();
    }

}