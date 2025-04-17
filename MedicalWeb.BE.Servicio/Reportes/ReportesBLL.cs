using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio;
public class ReportesBLL : IReportesBLL
{
    
    private readonly IReportesDAL _reportesDAL;

    public ReportesBLL(IReportesDAL reportesDAL)
    {
        _reportesDAL = reportesDAL;
    }

    public async Task<IEnumerable<Reporte>> GetAllReportesAsync()
    {
        return await _reportesDAL.GetAllAsync();
    }

    public async Task<Reporte> GetReporteByIdAsync(int id)
    {
        return await _reportesDAL.GetByIdAsync(id);
    }

    public async Task<Reporte> AddReporteAsync(Reporte reporte)
    {
        return await _reportesDAL.AddAsync(reporte);
    }

    public async Task<Reporte> UpdateReporteAsync(Reporte reporte)
    {
        return await _reportesDAL.UpdateAsync(reporte);
    }

    public async Task<bool> DeleteReporteAsync(int id)
    {
        return await _reportesDAL.DeleteAsync(id);
    }

}