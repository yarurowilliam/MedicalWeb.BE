using Auth0.ManagementApi.Models.Forms;
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
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paciente/{documentoPaciente}")]
        public async Task<IActionResult> GetPacienteByDocumento(string documentoPaciente)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(HistoriaClinicaDTO historiaClinicaDTO)
        {
            try
            {
                await _historiaClinicaBLL.InsertAsync(historiaClinicaDTO);
                return Ok("Historia clínica registrada con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(HistoriaClinicaDTO historiaClinicaDTO)
        {
            try
            {
                var updatedHistoriaClinica = await _historiaClinicaBLL.UpdateAsync(historiaClinicaDTO);
                return Ok(updatedHistoriaClinica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{numeroDocumento}")]
        public async Task<IActionResult> DeleteAsync(string numeroDocumento)
        {
            try
            {
                await _historiaClinicaBLL.DeleteAsync(numeroDocumento);
                return Ok("Historia clínica eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pacientes-con-historias")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<IActionResult> ObtenerPacientesConHistoriasClinicas()
        {
            try
            {
                var pacientes = await _historiaClinicaBLL.ObtenerPacientesConHistoriasClinicasAsync();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
