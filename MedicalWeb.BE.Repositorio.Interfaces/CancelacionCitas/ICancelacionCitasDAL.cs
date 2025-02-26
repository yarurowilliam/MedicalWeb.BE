using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface ICancelacionCitasDAL
{
    Task<IEnumerable<CancelacionCita>> GetCancelacionCita();
    Task<IEnumerable<CancelacionCita>> GetCitasCanceladasById(string id);
    Task<CancelacionCita> InsertCancelacionCita(CancelacionCita cancelacionCita);
    Task DeleteCancelacionCitaById(int id);

}