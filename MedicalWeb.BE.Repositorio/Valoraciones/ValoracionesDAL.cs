using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
namespace MedicalWeb.BE.Repositorio;

public class ValoracionesDAL : IValoracionesDAL
{
    private readonly MedicalWebDbContext _dbContext;

    public ValoracionesDAL(MedicalWebDbContext dbContext)
    {
       _dbContext = dbContext;
    }

    public async Task<Valoraciones> InsertarValoracion(Valoraciones valoraciones)
    {
        _dbContext.Valoraciones.Add(valoraciones);
        await _dbContext.SaveChangesAsync();
        return valoraciones;
    }

    public async Task<Valoraciones> UpdateValoracion(Valoraciones valoraciones)
    {
        _dbContext.Entry(valoraciones).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return valoraciones;
    }

    public async Task<IEnumerable<Valoraciones>> GetAllAsync()
    {
        return await _dbContext.Set<Valoraciones>().ToListAsync();
    }

    public async Task<IEnumerable<Valoraciones>> GetByIdAsync(string id)
    {
        return await _dbContext.Set<Valoraciones>()
                               .Where(v => v.NumMedico == id && v.Estado == 'A')
                               .ToListAsync();
    }


    public async Task<Valoraciones> DeleteValoracion(int id)
    {
        var valoracion = await _dbContext.Set<Valoraciones>().FindAsync(id);
        if (valoracion != null)
        {
            valoracion.Estado = 'I';
            await _dbContext.SaveChangesAsync();
        }

        return valoracion;
    }

}