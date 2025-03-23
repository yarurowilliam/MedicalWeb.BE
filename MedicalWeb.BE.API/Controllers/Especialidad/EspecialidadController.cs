﻿using MedicalWeb.BE.Servicio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EspecialidadController : ControllerBase
{
    private readonly IEspecialidadBLL _especialidadBLL;

    public EspecialidadController(IEspecialidadBLL especialidadBLL)
    {
        _especialidadBLL = especialidadBLL;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidadesAsync()
    {
        var especialidades = await _especialidadBLL.GetEspecialidadesAsync();
        return Ok(especialidades);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Especialidad>> GetEspecialidadByIdAsync(int id)
    {
        var especialidad = await _especialidadBLL.GetEspecialidadByIdAsync(id);
        if (especialidad == null)
        {
            return NotFound();
        }
        return Ok(especialidad);
    }

    [HttpPost]
    public async Task<ActionResult<Especialidad>> CreateEspecialidadAsync(Especialidad especialidad)
    {
        return await _especialidadBLL.CreateEspecialidadAsync(especialidad);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Especialidad>> UpdateEspecialidadAsync(int id, Especialidad especialidad)
    {
        if (id != especialidad.Id)
        {
            return BadRequest("El ID en la URL no coincide con el ID de la especialidad.");
        }

        // Verificar si la especialidad existe
        var especialidadExistente = await _especialidadBLL.GetEspecialidadByIdAsync(id);
        if (especialidadExistente == null)
        {
            return NotFound("La especialidad no existe.");
        }

        // Realizar la actualización
        var especialidadActualizada = await _especialidadBLL.UpdateEspecialidadAsync(especialidad);
        return Ok(especialidadActualizada);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<Especialidad>> DeleteEspecialidadAsync(int id)
    {
        var especialidad = await _especialidadBLL.GetEspecialidadByIdAsync(id);
        if (especialidad == null)
        {
            return NotFound();
        }

        var especialidadEliminada = await _especialidadBLL.DeleteEspecialidadAsync(id);
        return Ok(especialidadEliminada);
    }

    [HttpPatch("{id}/activar")]
    public async Task<IActionResult> ActivarAsync(int id)
    {
        try
        {
            await _especialidadBLL.ActivarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}
