using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MedicalWeb.BE.API.Controllers;

[Route("api/[controller]")]

public class ReportesController : ControllerBase
{
    private readonly IReportesBLL _reportesBLL;

    public ReportesController(IReportesBLL reportesBLL)
    {
        _reportesBLL = reportesBLL;
    }

    [HttpGet]
    public async Task<IEnumerable<Reporte>> GetAllAsync()
    {
        return await _reportesBLL.GetAllReportesAsync();
    }

    [HttpGet("{id}")]
    public async Task<Reporte> GetByIdAsync(int id)
    {
        return await _reportesBLL.GetReporteByIdAsync(id);
    }

    [HttpPost]
    public async Task<Reporte> InsertAsync([FromBody] Reporte reporte)
    {
        return await _reportesBLL.AddReporteAsync(reporte);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(int id)   
    {
        await _reportesBLL.DeleteReporteAsync(id);
    }

    [HttpPut("{id}")]
    public async Task<Reporte> UpdateAsync([FromBody]Reporte reporte)
    {
        return await _reportesBLL.UpdateReporteAsync(reporte);
    }

}