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
    public async Task<Pacientes> InsertAsync(Pacientes pacientes)
    {
        return await _pacientesBLL.InsertAsync(pacientes);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(string id)
    {
        await _pacientesBLL.DeleteAsync(id);
    }

    [HttpPut]
    public async Task<Pacientes> UpdateAsync(Pacientes pacientes)
    {
        return await _pacientesBLL.UpdateAsync(pacientes);
    }   
}