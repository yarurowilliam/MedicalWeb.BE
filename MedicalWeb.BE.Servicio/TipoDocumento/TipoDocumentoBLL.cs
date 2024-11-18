using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
namespace MedicalWeb.BE.Servicio;

public class TipoDocumentoBLL : ITipoDocumentoBLL
{
    public readonly ITipoDocumentoDAL _tipodocumentoDAL;

    public TipoDocumentoBLL(ITipoDocumentoDAL tipodocumentoDAL)
    {
        _tipodocumentoDAL = tipodocumentoDAL;
    }

    public async Task<TipoDocumento> CreateTipoDocumentoAsync(TipoDocumento tipodocumento)
    {        
        return await _tipodocumentoDAL.CreateTipoDocumentoAsync(tipodocumento);
    }

    public async Task<TipoDocumento> DeleteTipoDocumentoAsync(int id)
    {        
        return await _tipodocumentoDAL.DeleteTipoDocumentoAsync(id);
    }

    public async Task<TipoDocumento> UpdateTipoDocumentoAsync(TipoDocumento tipodocumento)
    {        
        return await _tipodocumentoDAL.UpdateTipoDocumentoAsync(tipodocumento);
    }

    public async Task<IEnumerable<TipoDocumento>> GetTipoDocumentosAsync()
    {
        return await _tipodocumentoDAL.GetTipoDocumentosAsync();
    }

    public async Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id)
    {
        return await _tipodocumentoDAL.GetTipoDocumentoByIdAsync(id);
    }
}