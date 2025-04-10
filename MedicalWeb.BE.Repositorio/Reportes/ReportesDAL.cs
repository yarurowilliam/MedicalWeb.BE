using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio;

public class ReportesDAL : IReportesDAL
{
    private readonly MedicalWebDbContext _context;

    public ReportesDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reporte>> GetAllAsync()
    {
        return await _context.Reporte.ToListAsync();
    }

    public async Task<Reporte> GetByIdAsync(int id)
    {
        return await _context.Reporte.FindAsync(id);
    }

    public async Task<Reporte> AddAsync(Reporte reporte)
    {
        await _context.Reporte.AddAsync(reporte);
        await _context.SaveChangesAsync();
        return reporte;
    }

    public async Task<Reporte> UpdateAsync(Reporte reporte)
    {
        if (reporte == null)
            throw new ArgumentNullException(nameof(reporte));

        var entity = await _context.Reporte.FindAsync(reporte.Id);
        if (entity == null)
            throw new Exception("Reporte no encontrado");

        _context.Entry(entity).CurrentValues.SetValues(reporte);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var reporte = await _context.Reporte.FindAsync(id);
        if (reporte == null)
        {
            return false;
        }
        _context.Reporte.Remove(reporte);
        await _context.SaveChangesAsync();
        return true;
    }

}