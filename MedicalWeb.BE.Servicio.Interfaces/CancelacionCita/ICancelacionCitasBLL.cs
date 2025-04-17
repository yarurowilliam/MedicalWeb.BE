using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface ICancelacionCitasBLL
{
    Task<IEnumerable<CancelacionCita>> GetCancelacionCita();
    Task<IEnumerable<CancelacionCita>> GetCitasCanceladasById(string id);
    Task<CancelacionCita> InsertCancelacionCita(CancelacionCita cancelacionCita);
    Task DeleteCancelacionCitaById(int id);
}