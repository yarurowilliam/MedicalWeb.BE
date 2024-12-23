using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
namespace MedicalWeb.BE.API.Controllers;

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

    [HttpGet("{id}")]
    public async Task<MedicoDTO> GetByIdAsync(string id)
    {
        return await _medicoBLL.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<Medico> InsertAsync(Medico medico)
    {
        return await _medicoBLL.InsertAsync(medico);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(string id)
    {
        await _medicoBLL.DeleteAsync(id);
    }

    [HttpPut]
    public async Task<Medico> UpdateAsync(Medico medico)
    {
        return await _medicoBLL.UpdateAsync(medico);
    }
}