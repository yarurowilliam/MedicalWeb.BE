using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
namespace MedicalWeb.BE.Repositorio;

public class UsuarioDAL : IUsuarioDAL
{

    private readonly MedicalWebDbContext _context;

    public UsuarioDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task DeleteUsuarioAsync(string id)
    {
        var usuario = await _context.Set<Usuario>().FindAsync(id);
        if (usuario != null)
        {
            usuario.Estado = 'I';
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
        return _context.Usuarios.ToList();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(string id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }
}