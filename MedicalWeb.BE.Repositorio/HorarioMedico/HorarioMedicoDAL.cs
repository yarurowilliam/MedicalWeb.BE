using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
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
        var diaExiste = await _context.Dias.AnyAsync(d => d.DiaID == horarioMedico.DiaID);
        if (!diaExiste)
            throw new InvalidOperationException("El día no existe.");

        var horaExiste = await _context.HorasMedicas.AnyAsync(h => h.HoraMedicaID == horarioMedico.HoraID);
            if (!horaExiste)
            throw new InvalidOperationException("La hora no es aceptada.");

        var estadoExiste = await _context.EstadoHorarioMedicos.AnyAsync(e => e.EstadoHorarioID == horarioMedico.EstadoHorarioID);
            if (!estadoExiste)
            throw new InvalidOperationException("El estado del horario no es válido.");

        var medicoExiste = await _context.Medicos.AnyAsync(m => m.NumeroDocumento == horarioMedico.NumeroDocumento);
            if (!medicoExiste)
            throw new InvalidOperationException("El médico no está registrado.");

        var existe = await _context.HorarioMedico.AnyAsync(h =>
            h.NumeroDocumento == horarioMedico.NumeroDocumento &&
            h.DiaID == horarioMedico.DiaID &&
            h.HoraID == horarioMedico.HoraID
        );

        if (existe)
            throw new InvalidOperationException("La hora ya está asignada.");

        horarioMedico.EstadoHorarioID = 1; 
        _context.HorarioMedico.Add(horarioMedico);
        await _context.SaveChangesAsync();
        return horarioMedico;
    }

    public async Task<HorarioMedico> UpdateHorarioMedicoAsync(HorarioMedico horarioMedico)
    {
        var diaExiste = await _context.Dias.AnyAsync(d => d.DiaID == horarioMedico.DiaID);
        if (!diaExiste)
            throw new InvalidOperationException("El día no existe.");

        var horaExiste = await _context.HorasMedicas.AnyAsync(h => h.HoraMedicaID == horarioMedico.HoraID);
        if (!horaExiste)
            throw new InvalidOperationException("La hora no es aceptada.");

        var estadoExiste = await _context.EstadoHorarioMedicos.AnyAsync(e => e.EstadoHorarioID == horarioMedico.EstadoHorarioID);
        if (!estadoExiste)
            throw new InvalidOperationException("El estado del horario no es válido.");

        var medicoExiste = await _context.Medicos.AnyAsync(m => m.NumeroDocumento == horarioMedico.NumeroDocumento);
        if (!medicoExiste)
            throw new InvalidOperationException("El médico no está registrado.");

        var ocupado = await _context.HorarioMedico.AnyAsync(h =>
            h.NumeroDocumento == horarioMedico.NumeroDocumento &&
            h.DiaID == horarioMedico.DiaID &&
            h.HoraID == horarioMedico.HoraID &&
            h.Id != horarioMedico.Id
        );

        if (ocupado)
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

    public async Task<IEnumerable<HorarioMedico>> GetHorarioMedicoAsync()
    {
        return await _context.HorarioMedico
            .ToListAsync();
    }

    public async Task<IEnumerable<HorarioMedico>> GetHorarioMedicoIdentificacionAsync(int Identificacion)
    {
        return await _context.HorarioMedico
            .Where(h => Convert.ToInt32(h.NumeroDocumento) == Identificacion)
            .ToListAsync();
    }

    public async Task<IEnumerable<HorarioMedico>> GetHorariosPorDiaYHoraAsync(string medicoId,int dia, int hora)
    {
        return await _context.HorarioMedico
            .Where(h => h.NumeroDocumento == medicoId && h.DiaID == dia && h.HoraID == hora)
            .ToListAsync();
    }
}