using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MedicalWeb.BE.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HorarioMedicoController : ControllerBase
{
    private readonly IHorarioMedicoBLL _horarioMedicoBLL;

    public HorarioMedicoController(IHorarioMedicoBLL horarioMedicoBLL)
    {
        _horarioMedicoBLL = horarioMedicoBLL;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HorarioMedicoDTO>>> GetHorariosAsync()
    {
        var horarios = await _horarioMedicoBLL.GetHorarioMedicoAsync();
        return Ok(horarios);
    }

    [HttpGet("{Identificacion}")]
    public async Task<ActionResult<HorarioMedico>> GetHorarioByIdentificacionAsync(int Identificacion)
    {
        var horario = await _horarioMedicoBLL.GetHorarioMedicoIdentificacionAsync(Identificacion);
        if (horario == null)
        {
            return NotFound();
        }   
        return Ok(horario);
    }

    [HttpPost]
    public async Task<ActionResult<HorarioMedico>> CreateHorarioAsync(HorarioMedico horarioMedico)
    {
        try
        {
            var horarioCreado = await _horarioMedicoBLL.CreateHorarioMedicoIdAsync(horarioMedico);
            return Created($"api/horariomedico/{horarioCreado.Id}", horarioCreado); 

        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<HorarioMedico>> UpdateHorarioAsync(int id, HorarioMedico horarioMedico)
    {
        if (id != horarioMedico.Id)
        {
            return BadRequest();
        }

        try
        {
            var horarioActualizado = await _horarioMedicoBLL.UpdateHorarioMedicoAsync(horarioMedico);
            return Ok(horarioActualizado);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<HorarioMedico>> DeleteHorarioAsync(int id)
    {
        var horario = await _horarioMedicoBLL.GetHorarioMedicoIdentificacionAsync(id);
        if (horario == null)
        {
            return NotFound();
        }

        var horarioEliminado = await _horarioMedicoBLL.DeleteHorarioMedicoAsync(id);
        return Ok(horarioEliminado);
    }

    [HttpGet("PacienteId")]
    public async Task<ActionResult<HorarioMedico>> GetHorarioByIdentificacionPacienteAsync(int Identificacion)
    {
        var horario = await _horarioMedicoBLL.GetHorarioMedicoIdentificacionPacienteAsync(Identificacion);
        if (horario == null)
        {
            return NotFound();
        }
        return Ok(horario);
    }

    [HttpPatch("{id}/sala")]
    public async Task<IActionResult> UpdateSala(int id, [FromBody] string salaId)
    {
        if (string.IsNullOrEmpty(salaId))
        {
            return BadRequest("El campo salaId no puede ser nulo o vacío");
        }

        try
        {
            await _horarioMedicoBLL.UpdateSalaIdAsync(id, salaId);
            return Ok("Sala actualizada correctamente");
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

}
