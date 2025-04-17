using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWeb.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoBLL _medicoBLL;

        public MedicoController(IMedicoBLL medicoBLL)
        {
            _medicoBLL = medicoBLL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> GetAllAsync()
        {
            var medicos = await _medicoBLL.GetAllAsync();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        [ActionName("GetMedicoById")]
        public async Task<ActionResult<MedicoDTO>> GetByIdAsync(string id)
        {
            var medico = await _medicoBLL.GetByIdAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        [HttpGet("MedicoActivos")]
        public async Task<IEnumerable<MedicoDTO>> GetMedicosActivo()
        {
            return await _medicoBLL.GetMedicosActivo();
        }

        [HttpPatch("{id}/activar")]
        public async Task<IActionResult> ActivarAsync(string id)
        {
            try
            {
                await _medicoBLL.ActivarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MedicoDTO>> InsertAsync([FromForm] MedicoDTO medicoDTO)
        {
            try
            {
                var resultado = await _medicoBLL.InsertAsync(medicoDTO);
                return CreatedAtAction("GetMedicoById", new { id = resultado.NumeroDocumento }, MedicoBLL.MapToDTO(resultado));
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MedicoDTO>> UpdateAsync(string id, [FromForm] MedicoDTO medicoDTO)
        {
            if (id != medicoDTO.NumeroDocumento)
            {
                return BadRequest("El ID en la URL no coincide con el ID del médico.");
            }

            try
            {
                var resultado = await _medicoBLL.UpdateAsync(medicoDTO);
                return Ok(MedicoBLL.MapToDTO(resultado));
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                await _medicoBLL.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("EstadosCiviles")]
        public async Task<IActionResult> GetMaritalStatuses()
        {
            var estadosCiviles = await Task.FromResult(MaritalStatus.GetAll());
            return Ok(estadosCiviles);
        }

        // Endpoint corregido para obtener las especialidades de un médico
        [HttpGet("{id}/especialidades")]
        public async Task<ActionResult<IEnumerable<MedicoEspecialidadUpdateListDto>>> GetMedicoEspecialidad(string id)
        {
            try
            {
                var especialidades = await _medicoBLL.GetMedicoEspecialidad(id);
                if (especialidades == null || !especialidades.Any())
                {
                    return NotFound($"No se encontraron especialidades para el médico con ID {id}");
                }

                // Las especialidades ya incluyen nombre y descripción, así que podemos devolverlas directamente
                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error Interno del Servidor: {ex.Message}");
            }
        }
    }
}

