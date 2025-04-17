using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Transversales.Entidades.MedicamentosRecetados;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers.Incapacidad
{

    [Route("api/[controller]")]
    [ApiController]
    public class IncapacidadController : ControllerBase
    {
        private readonly IIncapacidadBLL _incapacidadBLL;

        public IncapacidadController(IIncapacidadBLL incapacidadBLL)
        {
            _incapacidadBLL = incapacidadBLL;
        }

        [HttpGet("info/{documentoMedico}/{documentoPaciente}")]
        public async Task<IActionResult> GetMedicoYPacienteByDocumento(string documentoMedico, string documentoPaciente)
        {
            try
            {
                var resultado = await _incapacidadBLL.ObtenerInfoMedicoYPacienteAsync(documentoMedico, documentoPaciente);

                if (resultado == null)
                {
                    return NotFound("No se encontró el médico o el paciente");
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarIncapacidad([FromBody] IncapacidadDTO incapacidadDTO)
        {
            try
            {
                await _incapacidadBLL.InsertarIncapacidadAsync(incapacidadDTO);
                return Ok(new { mensaje = "Incapacidad insertada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al insertar Incapacidad", error = ex.Message });
            }
        }
    }
}
