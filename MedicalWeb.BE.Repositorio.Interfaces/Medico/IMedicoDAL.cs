using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IMedicoDAL
{
    Task<IEnumerable<Medico>> GetAllAsync();
    Task<IEnumerable<Medico>> GetMedicosActivo();
    Task<Medico> GetByIdAsync(string id);
    Task<Medico> InsertAsync(Medico medico);
    Task<Medico> UpdateAsync(Medico medico);
    Task DeleteAsync(string id);
    Task ActivarAsync(string id);
    Task<IEnumerable<MedicoEspecialidadUpdateDto2>> GetMedicoEspecialidad(string id);
}

