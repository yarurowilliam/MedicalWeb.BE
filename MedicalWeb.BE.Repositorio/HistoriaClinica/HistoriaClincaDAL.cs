using MedicalWeb.BE.Infraestructure.Migrations;
using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Encriptacion;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
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
        return await _context.HistoriaClinica
            .Include(h => h.Paciente)
            .Include(h => h.Medico)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoriaClinica>> ObtenerHistoriasClinicasPorMedicoAsync(int idMedico)
    {
        return await _context.HistoriaClinica
            .Where(h => h.NumeroDocumentoMedico == idMedico.ToString())
            .Include(h => h.Paciente)
            .Include(h => h.Medico)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoriaClinica>> ObtenerHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente)
    {
        return await _context.HistoriaClinica
            .Where(h => h.NumeroDocumentoPaciente == numeroDocumentoPaciente)
            .Include(h => h.Paciente)
            .Include(h => h.Medico)
            .ToListAsync();
    }


    public async Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO)
    {
        var HistoriaClinicas = new HistoriaClinica
        {
            NumeroDocumentoPaciente = historiaClinicaDTO.NumeroDocumentoPaciente,
            NumeroDocumentoMedico = historiaClinicaDTO.NumeroDocumentoMedico,
            NombreMedico = historiaClinicaDTO.NombreMedico,
            NombrePaciente = historiaClinicaDTO.NombrePaciente,
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
    public async Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente)
    {
        var medico = await _context.Medicos
            .FirstOrDefaultAsync(m => m.NumeroDocumento == documentoMedico);

        var paciente = await _context.Pacientes
            .FirstOrDefaultAsync(p => p.NumeroDocumento == documentoPaciente);

        if (medico == null || paciente == null)
        {
            return null;
        }

        return new MedicoPacienteDTO
        {
            Medico = new MedicoInfoDTO
            {
                Nombre = medico.PrimerNombre,
                SegundoNombre = medico.SegundoNombre,
                Apellido = medico.PrimerApellido,
                SegundoApellido = medico.SegundoApellido,
                Genero = medico.Genero,
                Correo = medico.CorreoElectronico,
                Telefono = medico.Telefono,
                Nacionalidad = medico.Nacionalidad,
                MatriculaProfesional = medico.MatriculaProfesional,
                NumeroDocumento = medico.NumeroDocumento,
                TipoDocumento = medico.TipoDocumento.ToString()
            },
            Paciente = new PacienteInfoDTO
            {
                Nombre = paciente.PrimerNombre,
                SegundoNombre = paciente.SegundoNombre,
                Apellido = paciente.PrimerApellido,
                SegundoApellido = paciente.SegundoApellido,
                Genero = paciente.Genero,
                Telefono = paciente.Telefono,
                Correo = paciente.CorreoElectronico,
                Ciudad = paciente.Ciudad,
                Departamento = paciente.Departamento,
                Pais = paciente.Pais,
                EstadoCivil = paciente.EstadoCivil.ToString(),
                Nacionalidad = paciente.Nacionalidad,
                GrupoSanguineo = paciente.GrupoSanguineo,
                NumeroDocumento = paciente.NumeroDocumento,
                TipoDocumento = paciente.TipoDocumento.ToString()
            }
        };
    }

}