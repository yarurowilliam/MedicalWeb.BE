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

        public async Task<bool> DeleteTipoDocumentoAsync(int id)
        {
            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
            if (tipoDocumento != null)
            {
                _context.TipoDocumento.Remove(tipoDocumento);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<TipoDocumento> UpdateTipoDocumentoAsync(TipoDocumento tipodocumento)
        {
            _context.TipoDocumento.Update(tipodocumento);
            await _context.SaveChangesAsync();
            return tipodocumento;
        }

        public async Task<IEnumerable<TipoDocumento>> GetTipoDocumentosAsync()
        {
            return await _context.TipoDocumento.ToListAsync();
        }

        public async Task<TipoDocumento> GetTipoDocumentoByIdAsync(int id)
        {
            return await _context.TipoDocumento.FindAsync(id);
        }
    }
}