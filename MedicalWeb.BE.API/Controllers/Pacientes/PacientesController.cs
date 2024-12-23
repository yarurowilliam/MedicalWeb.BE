using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
namespace MedicalWeb.BE.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly IPacientesBLL _pacientesBLL;

    public PacientesController(IPacientesBLL pacientesBLL)
    {
        _pacientesBLL = pacientesBLL;
    }

    [HttpGet]
    public async Task<IEnumerable<PacientesDTO>> GetAllAsync()
    {
        return await _pacientesBLL.GetAllAsync();
    }

    [HttpGet("{numeroDocumento}")]
    public async Task<PacientesDTO> GetByIdAsync(string numeroDocumento)
    {
        return await _pacientesBLL.GetByIdAsync(numeroDocumento);
    }

    [HttpPost]
    public async Task<PacientesDTO1> InsertAsync(PacientesDTO1 pacientes)
    {
        return await _pacientesBLL.InsertAsync(pacientes);
    }

    [HttpDelete("{numeroDocumento}")]
    public async Task DeleteAsync(string numeroDocumento)
    {
        await _pacientesBLL.DeleteAsync(numeroDocumento);
    }

    [HttpPut]
    public async Task<PacientesDTO1> UpdateAsync(PacientesDTO1 pacientes)
    {
        return await _pacientesBLL.UpdateAsync(pacientes);
    }   
}