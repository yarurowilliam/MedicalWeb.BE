using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades.MedicamentosRecetados;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers.MedicamentosRecetados
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosRecetadosController : ControllerBase
    {
     
         private readonly IMedicamentosRecetadosBLL _medicamentosRecetados;

         public MedicamentosRecetadosController(IMedicamentosRecetadosBLL medicamentosRecetados)
         {
            _medicamentosRecetados = medicamentosRecetados;
         }
        
        [HttpGet("info/{documentoMedico}/{documentoPaciente}")]
        public async Task<IActionResult> GetMedicoYPacienteByDocumento(string documentoMedico, string documentoPaciente)
        {
            try
            {
                var resultado = await _medicamentosRecetados.ObtenerInfoMedicoYPacienteAsync(documentoMedico, documentoPaciente);

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
        public async Task<IActionResult> InsertarReceta([FromBody] RecetaCompletaDTO recetaDTO)
        {
            try
            {
                await _medicamentosRecetados.InsertarRecetaConMedicamentosAsync(recetaDTO);
                return Ok(new { mensaje = "Receta insertada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al insertar receta", error = ex.Message });
            }
        }
    }
}
