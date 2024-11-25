using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IAlertasDal{
    Task<IEnumerable<Alerta>> GetAlertasAsync();
    Task<Alerta> GetAlertasByIdAsync(int id);
    Task<Alerta> CreateAlertasAsync(Alerta alerta);
    Task<Alerta> UpdateAlertasAsync(Alerta alerta);
    Task<Alerta> DeleteAlertasAsync(int id);  
}