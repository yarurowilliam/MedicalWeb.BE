using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("consultar/{medicoId}/{dia}/{hora}")]
    public async Task<ActionResult<IEnumerable<HorarioMedico>>> ConsultarHorariosPorDiaYHoraAsync(string medicoId, int dia, int hora)
    {
        var horarios = await _horarioMedicoBLL.ConsultarHorariosPorDiaYHoraAsync(medicoId, dia, hora);
        if (!horarios.Any())
        {
            return NotFound(new { message = "No se encontraron horarios para el médico en el día y hora especificados." });
        }
        return Ok(horarios);
    }
}