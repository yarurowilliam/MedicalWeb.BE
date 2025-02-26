using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio;

public class ValoracionesBLL : IValoracionesBLL
{
    private readonly IValoracionesDAL _valoracionesDAL;

    public ValoracionesBLL(IValoracionesDAL valoracionesDAL)
    {
        _valoracionesDAL = valoracionesDAL;
    }

    public async Task DeleteValoracion(int id)
    {
        await _valoracionesDAL.DeleteValoracion(id);
    }

    public async Task<Valoraciones> InsertarValoracion(Valoraciones valoraciones)
    {
        return await _valoracionesDAL.InsertarValoracion(valoraciones);
    }

    public async Task<Valoraciones> UpdateValoracion(Valoraciones valoraciones)
    {
        return await _valoracionesDAL.UpdateValoracion(valoraciones);
    }

    public async Task<IEnumerable<Valoraciones>> GetAllAsync()
    {
        return await _valoracionesDAL.GetAllAsync();
    }

    public async Task<IEnumerable<Valoraciones>> GetByIdAsync(string id)
    {
        return await _valoracionesDAL.GetByIdAsync(id);
    }
}