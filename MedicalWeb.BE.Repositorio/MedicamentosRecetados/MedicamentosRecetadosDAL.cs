using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Transversales.Entidades.MedicamentosRecetados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Repositorio;

public class MedicamentosRecetadosDAL: IMedicamentosRecetadosDAL
{
    private readonly MedicalWebDbContext _context;

    public MedicamentosRecetadosDAL(MedicalWebDbContext context)
    {
        _context = context;
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
                MatriculaProfesional = medico.MatriculaProfesional,
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
                NumeroDocumento = paciente.NumeroDocumento,
                TipoDocumento = paciente.TipoDocumento.ToString(),
                Direccion = paciente.Direccion
            }
        };
    }

    public async Task InsertarRecetaConMedicamentosAsync(RecetaCompletaDTO recetaDTO)
    {
        var receta = new Receta
        {
            NumeroDocumentoPaciente = recetaDTO.NumeroDocumentoPaciente,
            NumeroDocumentoMedico = recetaDTO.NumeroDocumentoMedico,
            FechaHora = recetaDTO.FechaHora,
            Diagnostico = recetaDTO.Diagnostico
        };

        await _context.Set<Receta>().AddAsync(receta);
        await _context.SaveChangesAsync();

        foreach (var med in recetaDTO.Medicamentos)
        {
            var medicamento = new MedicamentoRecetado
            {
                RecetaID = receta.ID,
                NombreMedicamento = med.NombreMedicamento,
                Concentracion = med.Concentracion,
                FormaFarmaceutica = med.FormaFarmaceutica,
                CantidadRecetada = med.CantidadRecetada,
                InstruccionesUso = med.InstruccionesUso
            };

            await _context.Set<MedicamentoRecetado>().AddAsync(medicamento);
        }

        await _context.SaveChangesAsync();
    }
}
