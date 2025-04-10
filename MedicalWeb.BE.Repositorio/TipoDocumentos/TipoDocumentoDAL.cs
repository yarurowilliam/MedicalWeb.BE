using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;

namespace MedicalWeb.BE.Repositorio
{
    public class TipoDocumentoDAL: ITipoDocumentoDAL
    {
        private readonly MedicalWebDbContext _context;

        public TipoDocumentoDAL(MedicalWebDbContext context)
        {
            _context = context;            
        }

        public async Task<TipoDocumento> CreateTipoDocumentoAsync(TipoDocumento tipodocumento)
        {
            _context.TipoDocumento.Add(tipodocumento);
            await _context.SaveChangesAsync();
            return tipodocumento;
        }

        public async Task<TipoDocumento> DeleteTipoDocumentoAsync(int id)
        {
            var tipodocumento = await _context.TipoDocumento.FindAsync(id);
            if (tipodocumento != null)
            {
                return null;
            }
            _context.TipoDocumento.Remove(tipodocumento);
            await _context.SaveChangesAsync();
            return tipodocumento;
        }

        public async Task<TipoDocumento> UpdateTipoDocumentoAsync(TipoDocumento tipodocumento)
        {
            _context.TipoDocumento.Update(tipodocumento);
            await _context.SaveChangesAsync();
            return tipodocumento;
        }

        public async Task<IEnumerable<TipoDocumento>> GetTipoDocumentosAsync()
        {
            return _context.TipoDocumento.ToList();
        }

        public async Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id)
        {
            return await _context.TipoDocumento.FindAsync(id);
        }
    }
}