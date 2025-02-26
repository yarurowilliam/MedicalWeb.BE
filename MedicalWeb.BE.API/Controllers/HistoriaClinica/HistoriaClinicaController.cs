using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Encriptacion;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedicalWeb.BE.API.Controllers.HistoriaClinica
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaClinicaController : ControllerBase
    {
        private readonly IHistoriaClinicaBLL _historiaClinicaBLL;
        private readonly IMedicoBLL _medicoBLL;
        private readonly IPacientesBLL _pacientesBLL;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HistoriaClinicaController(IHistoriaClinicaBLL historiaClinicaBLL, IMedicoBLL medicoBLL, IPacientesBLL pacientesBLL, IHttpContextAccessor httpContextAccessor)
        {
            _historiaClinicaBLL=historiaClinicaBLL;
            _medicoBLL=medicoBLL;
            _pacientesBLL=pacientesBLL;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("medico")]
        public async Task<IActionResult> ObtenerHistoriasClinicasPorMedicoAsync()
        {
            try
            {
                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                int idMedico = JwtConfiguration.GetTokenIdUsuario(identity);
                var historiasClinicas = await _historiaClinicaBLL.ObtenerHistoriasClinicasPorMedicoAsync(idMedico);
                return Ok(historiasClinicas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pacientes/historias/{numeroDocumentoPaciente}")]
        public async Task<IActionResult> ObtenerHistoriasClinicasPorPacienteAsync(string numeroDocumentoPaciente)
        {
            try
            {
                var historiasClinicas = await _historiaClinicaBLL.ObtenerHistoriasClinicasPorPacienteAsync(numeroDocumentoPaciente);
                return Ok(historiasClinicas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("medico/{documentoMedico}")]
        public async Task<IActionResult> GetMedicoByDocumento(string documentoMedico)
        {
            var medico = await _medicoBLL.GetByIdAsync(documentoMedico);

            if (medico == null)
            {
                return NotFound("Médico no encontrado");
            }

            return Ok(new
            {
                nombre = medico.PrimerNombre,
                segundoNombre = medico.SegundoNombre,
                apellido = medico.PrimerApellido,
                segundoApellido = medico.SegundoApellido,
                genero = medico.Genero
            });
        }

        [HttpGet("paciente/{documentoPaciente}")]
        public async Task<IActionResult> GetPacienteByDocumento(string documentoPaciente)
        {
            var paciente = await _pacientesBLL.GetByIdAsync(documentoPaciente);
            if (paciente == null)
            {
                return NotFound("Paciente no encontrado");
            }
            return Ok(new
            {
                nombre = paciente.PrimerNombre,
                segundoNombre = paciente.SegundoNombre,
                apellido = paciente.PrimerApellido,
                segundoApellido = paciente.SegundoApellido,
                genero = paciente.Genero,
                telefono = paciente.Telefono,
                correo = paciente.CorreoElectronico
            });
        }

        [HttpPost]
        public async Task<HistoriaClinicaDTO> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO)
        {
            return await _historiaClinicaBLL.InsertAsync(historiaClinicaDTO);
        }

        [HttpPut]
        public async Task<HistoriaClinicaDTO> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO)
        {
            return await _historiaClinicaBLL.UpdateAsync(historiaClinicaDTO);
        }

        [HttpDelete("{numeroDocumento}")]
        public async Task DeleteAsync(string numeroDocumento)
        {
            await _historiaClinicaBLL.DeleteAsync(numeroDocumento);
        }
    }
}
