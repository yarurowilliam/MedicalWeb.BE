using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<MedicoDTO>> GetAllAsync()
        {
            return await _medicoBLL.GetAllAsync();
        }

        [HttpGet("MedicoActivos")]
        public async Task<IEnumerable<MedicoDTO>> GetMedicosActivo()
        {
            return await _medicoBLL.GetMedicosActivo();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoDTO>> GetByIdAsync(string id)
        {
            var medico = await _medicoBLL.GetByIdAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            return medico;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] MedicoDTO medicoDTO)
        {
            var resultado = await _medicoBLL.InsertAsync(medicoDTO);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = resultado.NumeroDocumento }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromForm] MedicoDTO medicoDTO)
        {
            if (id != medicoDTO.NumeroDocumento)
            {
                return BadRequest("El ID en la URL no coincide con el ID del médico.");
            }

            var resultado = await _medicoBLL.UpdateAsync(medicoDTO);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _medicoBLL.DeleteAsync(id);
            return NoContent();
        }
    }
}