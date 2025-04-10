using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoEspecialidadController : ControllerBase
    {
        private readonly IMedicoEspecialidadBLL _medicoEspecialidadBLL;

        public MedicoEspecialidadController(IMedicoEspecialidadBLL medicoEspecialidadBLL)
        {
            _medicoEspecialidadBLL = medicoEspecialidadBLL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoEspecialidad>>> GetMedicosEspecialidadesAsync()
        {
            var medicosEspecialidades = await _medicoEspecialidadBLL.GetMedicosEspecialidadesAsync();
            return Ok(medicosEspecialidades);
        }

        [HttpGet("especialidad/{nombreEspecialidad}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidadByNameAsync(string nombreEspecialidad)
        {
            var medicos = await _medicoEspecialidadBLL.GetMedicosByEspecialidadAsync(nombreEspecialidad);

            if (medicos == null || !medicos.Any())
            {
                return NotFound();
            }

            return Ok(medicos);
        }

        [HttpPost]
        public async Task<ActionResult<MedicoEspecialidad>> CreateMedicoEspecialidadAsync([FromBody] MedicoEspecialidad medicoEspecialidad)
        {
            if (medicoEspecialidad == null)
            {
                return BadRequest("El objeto de asignación es nulo.");
            }

            try
            {
                var result = await _medicoEspecialidadBLL.InsertAsync(medicoEspecialidad);
                return StatusCode(201, new { message = "Asignación exitosa", data = result });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("No se pudo crear la asignación.");
            }
        }

        [HttpPut("medico/{medicoNumeroDocumento}/especialidad/{especialidadId}")]
        public async Task<ActionResult<MedicoEspecialidad>> UpdateMedicoEspecialidadAsync(string medicoNumeroDocumento, int especialidadId, [FromBody] MedicoEspecialidadUpdateDto medicoEspecialidadUpdateDto)
        {
            if (medicoNumeroDocumento != medicoEspecialidadUpdateDto.MedicoNumeroDocumento || especialidadId != medicoEspecialidadUpdateDto.EspecialidadId)
            {
                return BadRequest("Los datos de la URL no coinciden con los datos del cuerpo de la solicitud.");
            }

            try
            {
                var result = await _medicoEspecialidadBLL.UpdateAsync(medicoNumeroDocumento, especialidadId, medicoEspecialidadUpdateDto.EspecialidadIdNueva);
                if (result == null)
                {
                    return NotFound("No se encontró la asignación de médico y especialidad.");
                }

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Nuevo endpoint para actualizar todas las especialidades de un médico
        [HttpPost("update")]
        public async Task<IActionResult> UpdateMedicoEspecialidadesAsync([FromBody] MedicoEspecialidadUpdateListDto updateDto)
        {
            if (updateDto == null || string.IsNullOrEmpty(updateDto.MedicoNumeroDocumento))
            {
                return BadRequest("Datos de actualización inválidos.");
            }

            try
            {
                await _medicoEspecialidadBLL.UpdateMedicoEspecialidadesAsync(updateDto.MedicoNumeroDocumento, updateDto.EspecialidadesIds);
                return Ok(new { message = "Especialidades actualizadas correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar especialidades: {ex.Message}");
            }
        }

        [HttpDelete("medico/{medicoNumeroDocumento}/especialidad/{especialidadId}")]
        public async Task<IActionResult> DeleteMedicoEspecialidadAsync(string medicoNumeroDocumento, int especialidadId)
        {
            var medicoEspecialidad = await _medicoEspecialidadBLL.GetByMedicoAndEspecialidadAsync(medicoNumeroDocumento, especialidadId);
            if (medicoEspecialidad == null)
            {
                return NotFound();
            }

            await _medicoEspecialidadBLL.DeleteAsync(medicoNumeroDocumento, especialidadId);
            return NoContent();
        }

        [HttpGet("activas")]
        public async Task<ActionResult<IEnumerable<MedicoEspecialidad>>> GetMedicosEspecialidadesActivasAsync()
        {
            var medicosEspecialidadesActivas = await _medicoEspecialidadBLL.GetMedicosEspecialidadesActivasAsync();

            if (medicosEspecialidadesActivas == null || !medicosEspecialidadesActivas.Any())
            {
                return NotFound("No se encontraron especialidades activas.");
            }

            return Ok(medicosEspecialidadesActivas);
        }

        [HttpGet("inactivas")]
        public async Task<ActionResult<IEnumerable<MedicoEspecialidad>>> GetMedicosEspecialidadesInactivasAsync()
        {
            var medicosEspecialidadesInactivas = await _medicoEspecialidadBLL.GetMedicosEspecialidadesInactivasAsync();

            if (medicosEspecialidadesInactivas == null || !medicosEspecialidadesInactivas.Any())
            {
                return NotFound("No se encontraron especialidades inactivas.");
            }

            return Ok(medicosEspecialidadesInactivas);
        }

        // Nuevo endpoint para obtener las especialidades de un médico específico
        [HttpGet("medico/{medicoNumeroDocumento}")]
        public async Task<ActionResult<IEnumerable<MedicoEspecialidad>>> GetEspecialidadesByMedicoAsync(string medicoNumeroDocumento)
        {
            try
            {
                var especialidades = await _medicoEspecialidadBLL.GetEspecialidadesByMedicoAsync(medicoNumeroDocumento);

                if (especialidades == null || !especialidades.Any())
                {
                    return Ok(new List<MedicoEspecialidad>()); // Devolver lista vacía en lugar de 404
                }

                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener especialidades del médico: {ex.Message}");
            }
        }
    }
}

