using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MedicalWeb.BE.Repositorio;

public class CancelacionCitasDAL : ICancelacionCitasDAL
{
    private readonly MedicalWebDbContext _dbContext;

    public CancelacionCitasDAL (MedicalWebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CancelacionCita>> GetCancelacionCita()
    {
        return await _dbContext.cancelacionCita.ToListAsync();
    }

    public async Task<IEnumerable<CancelacionCita>> GetCitasCanceladasById(string id)
    {
        return await _dbContext.Set<CancelacionCita>()
            .Where(x => x.NumDocumentoPaciente == id)
            .ToListAsync();
    }

    public async Task<CancelacionCita> InsertCancelacionCita(CancelacionCita cancelacionCita)
    {
        await _dbContext.AddAsync(cancelacionCita);
        await _dbContext.SaveChangesAsync();
        return cancelacionCita;
    }

    public async Task DeleteCancelacionCitaById(int id)
    {
        var cancelacionCita = await _dbContext.cancelacionCita
            .FirstOrDefaultAsync(e => e.Id == id);
        if (cancelacionCita == null)
        {
            throw new InvalidOperationException("La cancelación de la cita no existe.");
        }
        _dbContext.cancelacionCita.Remove(cancelacionCita);
        await _dbContext.SaveChangesAsync();
    }

}
