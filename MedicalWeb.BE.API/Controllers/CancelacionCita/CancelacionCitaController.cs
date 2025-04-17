using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelacionCitaController : ControllerBase
    {
        private readonly ICancelacionCitasBLL _cancelacionCitaBLL;

        public CancelacionCitaController(ICancelacionCitasBLL cancelacionCitaBLL)
        {
            _cancelacionCitaBLL = cancelacionCitaBLL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancelacionCita>>> GetCancelacionCitaAsync()
        {
            var cancelacionCita = await _cancelacionCitaBLL.GetCancelacionCita();
            return Ok(cancelacionCita);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CancelacionCita>>> GetCitasCanceladasByIdAsync(string id)
        {
            var cancelacionCita = await _cancelacionCitaBLL.GetCitasCanceladasById(id);
            if (cancelacionCita == null)
            {
                return NotFound();
            }
            return Ok(cancelacionCita);
        }

        [HttpPost]

        public async Task<ActionResult<CancelacionCita>> InsertCancelacionCitaAsync(CancelacionCita cancelacionCita)
        {
            try
            {
                var cancelacionCitaCreada = await _cancelacionCitaBLL.InsertCancelacionCita(cancelacionCita);
                return Created($"api/cancelacioncita/{cancelacionCitaCreada.Id}", cancelacionCitaCreada);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCancelacionCitaByIdAsync(int id)
        {
            try
            {
                var cancelacionCita =  _cancelacionCitaBLL.DeleteCancelacionCitaById(id);
                return Ok(cancelacionCita);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}