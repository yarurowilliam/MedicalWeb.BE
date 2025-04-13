using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IReportesBLL
{
    Task<IEnumerable<Reporte>> GetAllReportesAsync();
    Task<Reporte> GetReporteByIdAsync(int id);
    Task<Reporte> AddReporteAsync(Reporte reporte);
    Task<Reporte> UpdateReporteAsync(Reporte reporte);
    Task<bool> DeleteReporteAsync(int id);
}