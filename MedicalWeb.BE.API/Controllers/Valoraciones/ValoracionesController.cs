using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalWeb.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoracionesController : ControllerBase
    {
        private readonly IValoracionesBLL _valoracionesBLL;

        public ValoracionesController(IValoracionesBLL valoracionesBLL)
        {
            _valoracionesBLL = valoracionesBLL;
        }

        [HttpPost]
        public async Task<ActionResult<Valoraciones>> InsertarValoracionAsync(Valoraciones valoraciones)
        {
            try
            {
                var valoracionCreada = await _valoracionesBLL.InsertarValoracion(valoraciones);
                return Created($"api/valoraciones/{valoracionCreada.id}", valoracionCreada);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Valoraciones>> UpdateValoracionAsync(int id, Valoraciones valoraciones)
        {
            if (id != valoraciones.id)
            {
                return BadRequest();
            }

            try
            {
                var valoracionActualizada = await _valoracionesBLL.UpdateValoracion(valoraciones);
                return Ok(valoracionActualizada);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteValoracionAsync(int id)
        {
            try
            {
                await _valoracionesBLL.DeleteValoracion(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Valoraciones>>> GetAllAsync()
        {
            var valoraciones = await _valoracionesBLL.GetAllAsync();
            return Ok(valoraciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Valoraciones>>> GetByIdAsync(string id)
        {
            var valoraciones = await _valoracionesBLL.GetByIdAsync(id);
            return Ok(valoraciones);
        }
    }
}
