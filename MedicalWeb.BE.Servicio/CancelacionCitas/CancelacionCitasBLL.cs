using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio;

public class CancelacionCitasBLL : ICancelacionCitasBLL
{
    private readonly ICancelacionCitasDAL cancelacionCitasDAL;

    public CancelacionCitasBLL(ICancelacionCitasDAL cancelacionCitasDAL)
    {
        this.cancelacionCitasDAL = cancelacionCitasDAL;
    }

    public async Task<CancelacionCita> InsertCancelacionCita(CancelacionCita cancelacionCita)
    {
        return await cancelacionCitasDAL.InsertCancelacionCita(cancelacionCita);
    }

    public async Task<IEnumerable<CancelacionCita>> GetCitasCanceladasById(string id)
    {
        return await cancelacionCitasDAL.GetCitasCanceladasById(id);
    }

    public async Task<IEnumerable<CancelacionCita>> GetCancelacionCita()
    {
        return await cancelacionCitasDAL.GetCancelacionCita();
    }

    public async Task DeleteCancelacionCitaById(int id)
    {
        await cancelacionCitasDAL.DeleteCancelacionCitaById(id);
    }
}
