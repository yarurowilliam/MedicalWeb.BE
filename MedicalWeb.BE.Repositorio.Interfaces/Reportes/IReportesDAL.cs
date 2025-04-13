using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IReportesDAL
{
    Task<IEnumerable<Reporte>> GetAllAsync();
    Task<Reporte> GetByIdAsync(int id);
    Task<Reporte> AddAsync(Reporte reporte);
    Task<Reporte> UpdateAsync(Reporte reporte);
    Task<bool> DeleteAsync(int id);
}