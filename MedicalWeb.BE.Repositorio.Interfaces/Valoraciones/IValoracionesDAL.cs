using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IValoracionesDAL
{
    Task<Valoraciones> InsertarValoracion(Valoraciones valoraciones);
    Task<Valoraciones> UpdateValoracion(Valoraciones valoraciones);
    Task<Valoraciones> DeleteValoracion (int id);
    Task<IEnumerable<Valoraciones>> GetByIdAsync(string id);
    Task<IEnumerable<Valoraciones>> GetAllAsync();

}