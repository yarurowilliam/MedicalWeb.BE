using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio;

public class AlertaDAL : IAlertasDal
{
    private readonly MedicalWebDbContext _context;

    public AlertaDAL(MedicalWebDbContext context)
    {
        _context=context;
    }

    public async Task<Alerta> CreateAlertasAsync(Alerta alerta)
    {       
        if (alerta.EstadoAlertaId == 0)
        {
            alerta.EstadoAlertaId = EstadoAlerta.Activo.Id;        }

        _context.Alertas.Add(alerta);
        await _context.SaveChangesAsync();
        return alerta;
    }

    public async Task<Alerta> DeleteAlertasAsync(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);
        if (alerta != null)
        {            
            alerta.Estado = EstadoAlerta.Omitido;
            await _context.SaveChangesAsync();
        }
        return alerta;
    }

    public async Task<IEnumerable<Alerta>> GetAlertasAsync()
    {
        return _context.Alertas.ToList();
    }

    public async Task<Alerta> GetAlertasByIdAsync(int id)
    {
        return await _context.Alertas.FindAsync(id);
    }

    public async Task<Alerta> UpdateAlertasAsync(Alerta alerta)
    {        
        if (alerta.EstadoAlertaId == 0)
        {
            alerta.EstadoAlertaId = EstadoAlerta.Activo.Id;
        }
        _context.Alertas.Update(alerta);
        await _context.SaveChangesAsync();
        return alerta;
    }    
}