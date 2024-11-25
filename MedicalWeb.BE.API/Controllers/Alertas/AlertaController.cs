using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
using static MedicalWeb.BE.Transversales.TipoDocumento;

namespace MedicalWeb.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertasBLL _alertasBLL;

        public AlertaController(IAlertasBLL alertasBLL)
        {
            _alertasBLL = alertasBLL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertasAsync()
        {
            var alerta = await _alertasBLL.GetAlertasAsync();
            return Ok(alerta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlertaByIdAsync(int id)
        {
            var alerta = await _alertasBLL.GetAlertasByIdAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }
            return Ok(alerta);
        }

        [HttpPost]
        public async Task<ActionResult<Alerta>> CreateAlertasAsync(Alerta alerta)
        {
            return await _alertasBLL.CreateAlertasAsync(alerta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Alerta>> UpdateAlertasAsync(int id, [FromBody] Alerta alerta)
        {
            if (id != alerta.IdAlerta)
            {
                return BadRequest();
            }         
            
            var alertaActualizada = await _alertasBLL.UpdateAlertasAsync(alerta);
            return Ok(alertaActualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Alerta>> DeleteAlertaAsync(int id)
        {
            var alerta = await _alertasBLL.GetAlertasByIdAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            var alertaEliminada = await _alertasBLL.DeleteAlertasAsync(id);
            return Ok(alertaEliminada);
        }
    }
}