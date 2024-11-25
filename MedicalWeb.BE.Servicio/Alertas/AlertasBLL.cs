using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio;

public class AlertasBLL: IAlertasBLL
{
    private readonly IAlertasDal _alertasDAL;
    public AlertasBLL(IAlertasDal alertasDAL)
    {
        _alertasDAL = alertasDAL;
    }

    public async Task<Alerta> CreateAlertasAsync(Alerta alerta)
    {
        return await _alertasDAL.CreateAlertasAsync(alerta);
    }

    public async Task<Alerta> DeleteAlertasAsync(int id)
    {
        return await _alertasDAL.DeleteAlertasAsync(id);
    }

    public async Task<IEnumerable<Alerta>> GetAlertasAsync()
    {
        return await _alertasDAL.GetAlertasAsync();
    }

    public async Task<Alerta> GetAlertasByIdAsync(int id)
    {
        return await _alertasDAL.GetAlertasByIdAsync(id);
    }

    public async Task<Alerta> UpdateAlertasAsync(Alerta alerta)
    {
        return await _alertasDAL.UpdateAlertasAsync(alerta);
    }
}