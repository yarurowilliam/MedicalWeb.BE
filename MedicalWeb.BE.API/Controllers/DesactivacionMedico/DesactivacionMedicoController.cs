using Microsoft.AspNetCore.Mvc;
using MedicalWeb.BE.BLL.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Controllers
{
    [Route("api/desactivacion-medico")]
    [ApiController]
    public class DesactivacionMedicoController : ControllerBase
    {
        private readonly IDesactivacionMedicoBLL _desactivacionMedicoBLL;

        public DesactivacionMedicoController(IDesactivacionMedicoBLL desactivacionMedicoBLL)
        {
            _desactivacionMedicoBLL = desactivacionMedicoBLL;
        }

        // GET: api/desactivacion-medico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesactivacionMedico>>> GetDesactivaciones()
        {
            try
            {
                var desactivaciones = await _desactivacionMedicoBLL.GetDesactivacionesAsync();
                return Ok(desactivaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/desactivacion-medico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesactivacionMedico>> GetDesactivacion(int id)
        {
            try
            {
                var desactivacion = await _desactivacionMedicoBLL.GetDesactivacionByIdAsync(id);

                if (desactivacion == null)
                {
                    return NotFound($"No se encontró la desactivación con ID {id}");
                }

                return Ok(desactivacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/desactivacion-medico/medico/12345678
        [HttpGet("medico/{numeroDocumento}")]
        public async Task<ActionResult<IEnumerable<DesactivacionMedico>>> GetDesactivacionesByMedico(string numeroDocumento)
        {
            try
            {
                var desactivaciones = await _desactivacionMedicoBLL.GetDesactivacionesByMedicoAsync(numeroDocumento);
                return Ok(desactivaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/desactivacion-medico/medico/activas/12345678
        [HttpGet("medico/activas/{numeroDocumento}")]
        public async Task<ActionResult<IEnumerable<DesactivacionMedico>>> GetDesactivacionesActivasByMedico(string numeroDocumento)
        {
            try
            {
                var desactivaciones = await _desactivacionMedicoBLL.GetDesactivacionesActivasByMedicoAsync(numeroDocumento);
                return Ok(desactivaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/desactivacion-medico
        [HttpPost]
        public async Task<ActionResult<DesactivacionMedico>> PostDesactivacion(DesactivacionMedico desactivacion)
        {
            try
            {
                var result = await _desactivacionMedicoBLL.CreateDesactivacionAsync(desactivacion);
                return CreatedAtAction(nameof(GetDesactivacion), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/desactivacion-medico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesactivacion(int id, DesactivacionMedico desactivacion)
        {
            if (id != desactivacion.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del objeto");
            }

            try
            {
                await _desactivacionMedicoBLL.UpdateDesactivacionAsync(desactivacion);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE: api/desactivacion-medico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DesactivacionMedico>> DeleteDesactivacion(int id)
        {
            try
            {
                var result = await _desactivacionMedicoBLL.DeleteDesactivacionAsync(id);
                
                if (!result)
                {
                    return NotFound($"No se encontró la desactivación con ID {id}");
                }

                return Ok(new { message = "Desactivación eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/desactivacion-medico/activar/12345678
        [HttpPost("activar/{numeroDocumento}")]
        public async Task<IActionResult> ActivarMedico(string numeroDocumento)
        {
            try
            {
                var result = await _desactivacionMedicoBLL.DesactivarDesactivacionesByMedicoAsync(numeroDocumento);
                
                if (!result)
                {
                    return NotFound($"No se encontraron desactivaciones activas para el médico {numeroDocumento}");
                }

                return Ok(new { message = "Médico activado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/desactivacion-medico/verificar-vencidas
        [HttpPost("verificar-vencidas")]
        public async Task<IActionResult> VerificarDesactivacionesVencidas()
        {
            try
            {
                var result = await _desactivacionMedicoBLL.VerificarYActualizarDesactivacionesVencidasAsync();
                
                if (!result)
                {
                    return Ok(new { message = "No hay desactivaciones vencidas para procesar" });
                }

                return Ok(new { message = "Desactivaciones vencidas procesadas correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
