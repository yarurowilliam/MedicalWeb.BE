using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Encriptacion;
using Microsoft.EntityFrameworkCore;
using MedicalWeb.BE.Transversales.Entidades;
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
		
		bool existeIdentificacion = await _context.Usuarios.AnyAsync(u => u.Identificacion == usuario.Identificacion);
		if (existeIdentificacion)
		{
			throw new InvalidOperationException("Ya existe un usuario con la misma identificación.");
		}

		bool existeNombreUsuario = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario);
		if (existeNombreUsuario)
		{
			throw new InvalidOperationException("Ya existe un usuario con el mismo nombre de usuario.");
		}

		
		usuario.Password = Encrypt.EncriptarContrasena(usuario.Password);
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
		return await _context.Usuarios.ToListAsync();
	}

	public async Task<Usuario> GetUsuarioByIdAsync(string id)
	{
		return await _context.Usuarios.FindAsync(id);
	}

	public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
	{
		
		bool existeIdentificacion = await _context.Usuarios
			.AnyAsync(u => u.Identificacion == usuario.Identificacion && u.Identificacion != usuario.Identificacion);
		if (existeIdentificacion)
		{
			throw new InvalidOperationException("Ya existe un usuario con la misma identificación.");
		}

		bool existeNombreUsuario = await _context.Usuarios
			.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario && u.Identificacion != usuario.Identificacion);
		if (existeNombreUsuario)
		{
			throw new InvalidOperationException("Ya existe un usuario con el mismo nombre de usuario.");
		}
		
		usuario.Password = Encrypt.EncriptarContrasena(usuario.Password);
		_context.Usuarios.Update(usuario);
		await _context.SaveChangesAsync();
		return usuario;
	}
}
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
        return await _context.Set<Usuario>().ToListAsync();
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