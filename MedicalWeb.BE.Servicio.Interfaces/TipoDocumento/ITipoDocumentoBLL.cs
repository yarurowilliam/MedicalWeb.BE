using MedicalWeb.BE.Transversales;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface ITipoDocumentoBLL
{
    Task<IEnumerable<TipoDocumento>> GetTipoDocumentosAsync();
    Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id);
    Task<TipoDocumento> CreateTipoDocumentoAsync(TipoDocumento tipodocumento);
    Task<TipoDocumento> UpdateTipoDocumentoAsync(TipoDocumento tipodocumento);
    Task<TipoDocumento> DeleteTipoDocumentoAsync(int id);
}