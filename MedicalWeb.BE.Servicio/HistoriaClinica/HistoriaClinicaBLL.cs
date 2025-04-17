using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio;

public class HistoriaClinicaBLL: IHistoriaClinicaBLL
{
    private readonly IHistoriaClinicaDAL _historiaClinicaDAL;


    public HistoriaClinicaBLL(IHistoriaClinicaDAL historiaClinicaDAL)
    {
        _historiaClinicaDAL = historiaClinicaDAL;
    }
    public async Task DeleteAsync(string numeroDocumento)
    {
        await _historiaClinicaDAL.DeleteAsync(numeroDocumento);
    }

    public async Task<IEnumerable<HistoriaClinicaDTO>> GetAllAsync()
    {
        var historiaClinica = await _historiaClinicaDAL.GetAllAsync();
        return MapToDTO(historiaClinica);
    }

    public async Task<IEnumerable<HistoriaClinicaDTO>> ObtenerHistoriasClinicasPorMedicoAsync(int idMedico)
    {
        var historiasClinicas = await _historiaClinicaDAL.ObtenerHistoriasClinicasPorMedicoAsync(idMedico);
        return historiasClinicas.Select(MapToDTO);
    }

    public async Task<IEnumerable<HistoriaClinicaDTO>> ObtenerHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente)
    {
        var historiasClinicas = await _historiaClinicaDAL.ObtenerHistoriasClinicasPorPacienteAsync(numeroDocumentoPaciente);
        return historiasClinicas.Select(MapToDTO);
    }

    private static HistoriaClinicaDTO MapToDTO(HistoriaClinica historiaClinica)
    {
        return new HistoriaClinicaDTO
        {
            NumeroDocumentoPaciente = historiaClinica.NumeroDocumentoPaciente,
            NombrePaciente = historiaClinica.NombrePaciente,
            NumeroDocumentoMedico = historiaClinica.NumeroDocumentoMedico,
            NombreMedico = historiaClinica.NombreMedico,
            FechaConsulta = historiaClinica.FechaConsulta,
            MotivoConsulta = historiaClinica.MotivoConsulta,
            Alergias = historiaClinica.Alergias,
            MedicamentosActuales = historiaClinica.MedicamentosActuales,
            AntecedentesFamiliares = historiaClinica.AntecedentesFamiliares,
            AntecedentesPersonales = historiaClinica.AntecedentesPersonales,
            Sintomas = historiaClinica.Sintomas,
            ObservacionesMedicas = historiaClinica.ObservacionesMedicas,
            DiagnosticoPrincipal = historiaClinica.DiagnosticoPrincipal,
            PlanTratamiento = historiaClinica.PlanTratamiento,
            MedicamentosRecetados = historiaClinica.MedicamentosRecetados,
            Dosis = historiaClinica.Dosis,
            DuracionTratamiento = historiaClinica.DuracionTratamiento,
            EstadoActivo = historiaClinica.EstadoActivo
        };
    }

    public static MedicoDTO MedicoMapToDTO(Medico medico)
    {
        return new MedicoDTO
        {
            NumeroDocumento = medico.NumeroDocumento,
            PrimerNombre = medico.PrimerNombre,
            PrimerApellido = medico.PrimerApellido,
            Genero = medico.Genero
        };
    }

    public static IEnumerable<HistoriaClinicaDTO> MapToDTO(IEnumerable<HistoriaClinica> historiaClinicas)
    {
        return historiaClinicas.Select(MapToDTO);
    }

    public async Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinica)
    {
        return await _historiaClinicaDAL.InsertAsync(historiaClinica);
    }

    public async Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinica)
    {
        return await _historiaClinicaDAL.UpdateAsync(historiaClinica);
    }

    public Task<HistoriaClinicaDTO> GetByIdAsync(int idusuario)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PacienteConHistoriaDTO>> ObtenerPacientesConHistoriasClinicasAsync()
    {
        var todasLasHistorias = await _historiaClinicaDAL.GetAllAsync();
        var pacientesConHistorias = todasLasHistorias
            .GroupBy(h => h.NumeroDocumentoPaciente)
            .Select(g => new PacienteConHistoriaDTO
            {
                NumeroDocumento = g.Key,
                NombreCompleto = g.First().NombrePaciente,
                UltimaConsulta = g.Max(h => h.FechaConsulta)
            })
            .OrderByDescending(p => p.UltimaConsulta);

        return pacientesConHistorias;
    }

    public async Task<IEnumerable<HistoriaClinicaDTO>> ObtenerTodasHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente)
    {
        var historiasClinicas = await _historiaClinicaDAL.ObtenerHistoriasClinicasPorPacienteAsync(numeroDocumentoPaciente);
        return historiasClinicas.Select(MapToDTO);
    }

    public async Task<MedicoPacienteDTO> ObtenerInfoMedicoYPacienteAsync(string documentoMedico, string documentoPaciente)
    {
        return await _historiaClinicaDAL.ObtenerInfoMedicoYPacienteAsync(documentoMedico, documentoPaciente);
    }
}
