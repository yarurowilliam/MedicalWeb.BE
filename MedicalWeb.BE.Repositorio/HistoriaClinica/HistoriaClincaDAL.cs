using MedicalWeb.BE.Infraestructure.Migrations;
using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Repositorio;

public class HistoriaClincaDAL : IHistoriaClinicaDAL
{
    private readonly MedicalWebDbContext _context;
    public HistoriaClincaDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HistoriaClinica>> GetAllAsync()
    {
        return await _context.Set<HistoriaClinica>().ToListAsync();
    }

    public async Task<HistoriaClinica> GetByIdAsync(string numeroDocumento)
    {
        return await _context.Set<HistoriaClinica>().FirstOrDefaultAsync(x => x.NumeroDocumentoPaciente == numeroDocumento);
    }

    public async Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO)
    {
        var HistoriaClinicas = new HistoriaClinica
        {
            NumeroDocumentoPaciente = historiaClinicaDTO.NumeroDocumentoPaciente,
            NumeroDocumentoMedico = historiaClinicaDTO.NumeroDocumentoMedico,
            FechaConsulta = historiaClinicaDTO.FechaConsulta,
            MotivoConsulta = historiaClinicaDTO.MotivoConsulta,
            Alergias = historiaClinicaDTO.Alergias,
            MedicamentosActuales = historiaClinicaDTO.MedicamentosActuales,
            AntecedentesFamiliares = historiaClinicaDTO.AntecedentesFamiliares,
            AntecedentesPersonales = historiaClinicaDTO.AntecedentesPersonales,
            Sintomas = historiaClinicaDTO.Sintomas,
            ObservacionesMedicas = historiaClinicaDTO.ObservacionesMedicas,
            DiagnosticoPrincipal = historiaClinicaDTO.DiagnosticoPrincipal,
            PlanTratamiento = historiaClinicaDTO.PlanTratamiento,
            MedicamentosRecetados = historiaClinicaDTO.MedicamentosRecetados,
            Dosis = historiaClinicaDTO.Dosis,
            DuracionTratamiento = historiaClinicaDTO.DuracionTratamiento,
            EstadoActivo = historiaClinicaDTO.EstadoActivo,
        };

        await _context.HistoriaClinica.AddAsync(HistoriaClinicas);

        await _context.SaveChangesAsync();
        return historiaClinicaDTO;
    }

    public async Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO)
    {
        var existingHistoriaClinica = await _context.Set<HistoriaClinica>().FindAsync(historiaClinicaDTO.NumeroDocumentoPaciente);

        if (existingHistoriaClinica != null)
        {
            existingHistoriaClinica.NumeroDocumentoPaciente = historiaClinicaDTO.NumeroDocumentoPaciente;
            existingHistoriaClinica.NumeroDocumentoMedico = historiaClinicaDTO.NumeroDocumentoMedico;
            existingHistoriaClinica.FechaConsulta = historiaClinicaDTO.FechaConsulta;
            existingHistoriaClinica.MotivoConsulta = historiaClinicaDTO.MotivoConsulta;
            existingHistoriaClinica.MotivoConsulta = historiaClinicaDTO.MotivoConsulta;
            existingHistoriaClinica.Alergias = historiaClinicaDTO.Alergias;
            existingHistoriaClinica.MedicamentosActuales = historiaClinicaDTO.MedicamentosActuales;
            existingHistoriaClinica.AntecedentesFamiliares = historiaClinicaDTO.AntecedentesFamiliares;
            existingHistoriaClinica.AntecedentesPersonales = historiaClinicaDTO.AntecedentesPersonales;
            existingHistoriaClinica.Sintomas = historiaClinicaDTO.Sintomas;
            existingHistoriaClinica.ObservacionesMedicas = historiaClinicaDTO.ObservacionesMedicas;
            existingHistoriaClinica.DiagnosticoPrincipal = historiaClinicaDTO.DiagnosticoPrincipal;
            existingHistoriaClinica.PlanTratamiento = historiaClinicaDTO.PlanTratamiento;
            existingHistoriaClinica.MedicamentosRecetados = historiaClinicaDTO.MedicamentosRecetados;
            existingHistoriaClinica.Dosis = historiaClinicaDTO.Dosis;
            existingHistoriaClinica.DuracionTratamiento = historiaClinicaDTO.DuracionTratamiento;
           // existingHistoriaClinica.EstadoActivo = historiaClinicaDTO.EstadoActivo;

            await _context.SaveChangesAsync();
        }
        return historiaClinicaDTO;
    }

    public async Task DeleteAsync(string numeroDocumento)
    {
        var historiaClinica = await _context.Set<HistoriaClinica>()
            .FirstOrDefaultAsync(x => x.NumeroDocumentoPaciente == numeroDocumento);
        if (historiaClinica != null)
        {
            historiaClinica.EstadoActivo = Convert.ToChar("I");
            await _context.SaveChangesAsync();
        }
    }
}
