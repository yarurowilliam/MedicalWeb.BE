using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Encriptacion;
using Microsoft.EntityFrameworkCore;
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
        usuario.Password = Encrypt.EncriptarContrasena(usuario.Password);
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task DeleteUsuarioAsync(string id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            usuario.Estado = 'I';
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
        return _context.Usuario.ToList();
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(string id)
    {
        var usuarios = await _context.Usuarios
            .Where(ur => ur.Identificacion == id)
            .ToListAsync();

        return usuarios;
    }

    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        bool existeRol = await _context.Usuarios
            .AnyAsync(u => u.RolId == usuario.RolId && u.Identificacion == usuario.Identificacion);
        if (existeRol)
        {
            throw new InvalidOperationException("Ya existe un usuario con el mismo rol asignado.");
        }
    
        usuario.Password = Encrypt.EncriptarContrasena(usuario.Password);
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada)
    {
        return await _context.Usuarios
            .Where(u => u.NombreUsuario == nombreUsuario &&
                        u.Password == passwordEncriptada &&
                        u.Estado == 'A')
            .ToListAsync();
    }
}