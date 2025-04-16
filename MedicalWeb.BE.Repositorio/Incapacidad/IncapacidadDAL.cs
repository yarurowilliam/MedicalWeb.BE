using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Repositorio;

public class IncapacidadDAL: IIncapacidadDAL
{
    private readonly MedicalWebDbContext _context;

    public IncapacidadDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente)
    {
        var medico = await _context.Medicos
            .FirstOrDefaultAsync(m => m.NumeroDocumento == documentoMedico);

        var paciente = await _context.Pacientes
            .FirstOrDefaultAsync(p => p.NumeroDocumento == documentoPaciente);

        var especialidadMedico = await _context.MedicoEspecialidades
            .Where(me => me.MedicoNumeroDocumento == documentoMedico)
            .Select(me => _context.Especialidades
                .FirstOrDefault(e => e.Id == me.EspecialidadId).Nombre)
            .FirstOrDefaultAsync();

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
                NumeroDocumento = medico.NumeroDocumento,
                TipoDocumento = medico.TipoDocumento.ToString(),
                Especialidad = especialidadMedico
            },
            Paciente = new PacienteInfoDTO
            {
                Nombre = paciente.PrimerNombre,
                SegundoNombre = paciente.SegundoNombre,
                Apellido = paciente.PrimerApellido,
                SegundoApellido = paciente.SegundoApellido,
                Genero = paciente.Genero,
                NumeroDocumento = paciente.NumeroDocumento,
                TipoDocumento = paciente.TipoDocumento.ToString(),
                Direccion = paciente.Direccion,
                Correo = paciente.CorreoElectronico
            }
        };
    }

    public async Task InsertarIncapacidadAsync(IncapacidadDTO incapacidadDTO)
    {
        var incapacidad = new Incapacidad
        {
            NumeroDocumentoPaciente = incapacidadDTO.NumeroDocumentoPaciente,
            NumeroDocumentoMedico = incapacidadDTO.NumeroDocumentoMedico,
            FechaGeneracion = incapacidadDTO.FechaGeneracion,
            Diagnostico = incapacidadDTO.Diagnostico,
            Origen = incapacidadDTO.Origen,
            Clasificacion = incapacidadDTO.Clasificacion,
            FechaInicio = incapacidadDTO.FechaInicio,
            FechaFin = incapacidadDTO.FechaFin,
            DuracionDias = incapacidadDTO.DuracionDias,
            NumeroPrescripcionSustituida = incapacidadDTO.NumeroPrescripcionSustituida
        };

        await _context.Set<Incapacidad>().AddAsync(incapacidad);
        await _context.SaveChangesAsync();
    }
}
