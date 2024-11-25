using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IAlertasBLL
{    Task<IEnumerable<Alerta>> GetAlertasAsync();
    Task<Alerta> GetAlertasByIdAsync(int id);
    Task<Alerta> CreateAlertasAsync(Alerta alerta);
    Task<Alerta> UpdateAlertasAsync(Alerta alerta);
    Task<Alerta> DeleteAlertasAsync(int id);
}