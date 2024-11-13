using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio;

public class MedicoBLL : IMedicoBLL
{
    private readonly IMedicoDAL _medicoDAL;

    public MedicoBLL(IMedicoDAL medicoDAL)
    {
        _medicoDAL = medicoDAL;
    }

    public async Task DeleteAsync(string id)
    {
        await _medicoDAL.DeleteAsync(id);
    }

    public async Task<IEnumerable<Medico>> GetAllAsync()
    {
        return await _medicoDAL.GetAllAsync();
    }

    public async Task<Medico> GetByIdAsync(string id)
    {
        return await _medicoDAL.GetByIdAsync(id);
    }

    public async Task<Medico> InsertAsync(Medico medico)
    {
        return await _medicoDAL.InsertAsync(medico);
    }

    public async Task<Medico> UpdateAsync(Medico medico)
    {
        return await _medicoDAL.UpdateAsync(medico);
    }
}