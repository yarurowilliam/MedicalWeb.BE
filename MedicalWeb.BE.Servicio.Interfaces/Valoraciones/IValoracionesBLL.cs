using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IValoracionesBLL 
{
    Task<Valoraciones> InsertarValoracion(Valoraciones valoraciones);
    Task <Valoraciones> UpdateValoracion(Valoraciones valoraciones);
    Task DeleteValoracion(int id);
    Task<IEnumerable<Valoraciones>> GetByIdAsync(string id);
    Task<IEnumerable<Valoraciones>> GetAllAsync();
}