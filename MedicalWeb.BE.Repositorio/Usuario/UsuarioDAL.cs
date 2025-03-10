using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Encriptacion;
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
        usuario.Password = Encrypt.EncriptarContrasena(usuario.Password);
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task DeleteUsuarioAsync(string identificacion)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Identificacion == identificacion);

        if (usuario != null)
        {
            usuario.Estado = 'I'; 
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync()
    {
        var usuarios = await _context.Usuarios.ToListAsync(); // Traemos todos los usuarios primero

        var usuariosDTO = usuarios
            .Select(u => new UsuarioDTO
            {
                UsuarioID = u.UsuarioID,
                Identificacion = u.Identificacion,
                NombreUsuario = u.NombreUsuario,
                Password = u.Password,
                Estado = u.Estado,

                RolId = string.Join(", ", usuarios.Where(x => x.Identificacion == u.Identificacion)
                                                  .Select(x => Rol.GetRolById(x.RolId)?.Nombre ?? "Desconocido")
                                                  .Distinct()),

                // Obtener correos en memoria
                Correos = string.Join(", ",
                    _context.Pacientes.AsEnumerable()
                        .Where(p => p.NumeroDocumento == u.Identificacion)
                        .Select(p => p.CorreoElectronico)
                    .Concat(
                        _context.Medicos.AsEnumerable()
                        .Where(m => m.NumeroDocumento == u.Identificacion)
                        .Select(m => m.CorreoElectronico))
                    .Distinct()
                )
            })
            .GroupBy(u => u.Identificacion) // Agrupar por Identificación para evitar duplicados
            .Select(g => g.First()) // Tomamos solo un registro por Identificación
            .ToList();

        return usuariosDTO;
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(string id)
    {
        var usuarios = await _context.Usuarios
            .Where(ur => ur.Identificacion == id)
            .ToListAsync();

        return usuarios;
    }

    public async Task<UsuarioUpdate> UpdateUsuarioAsync(UsuarioUpdate usuario)
    {
        var usuarioExistente = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Identificacion == usuario.Identificacion);

        if (usuarioExistente == null)
        {
            throw new KeyNotFoundException("El usuario no existe.");
        }

        // Mantener el RolId del usuario existente
        usuario.UsuarioID = usuarioExistente.UsuarioID;

        // Actualizar los campos con los nuevos valores
        usuarioExistente.NombreUsuario = usuario.NombreUsuario;
        usuarioExistente.Password = Encrypt.EncriptarContrasena(usuario.Password);
        usuarioExistente.Estado = usuario.Estado;

        // Evitar la modificación de RolId
        _context.Entry(usuarioExistente).Property(u => u.RolId).IsModified = false;

        await _context.SaveChangesAsync();

        return new UsuarioUpdate
        {
            UsuarioID = usuarioExistente.UsuarioID,
            Identificacion = usuarioExistente.Identificacion,
            NombreUsuario = usuarioExistente.NombreUsuario,
            Password = usuario.Password, // Retornamos la nueva contraseña en texto plano si es necesario
            Estado = usuarioExistente.Estado
        };
    }


    public async Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada)
    {
        return await _context.Usuarios
            .Where(u => u.Identificacion == nombreUsuario &&
                        u.Password == passwordEncriptada &&
                        u.Estado == 'A')
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Usuario>> ObtenerUsuariosPorIdentificacionAsync(string identificacion)
    {
        return await _context.Usuario
        .Where(u => u.Identificacion == identificacion)
        .ToListAsync();
    }

    public async Task EliminarRolesUsuarioAsync(string identificacion, List<int> rolesAEliminar)
    {
        var usuarios = await _context.Usuario
            .Where(u => u.Identificacion == identificacion && rolesAEliminar.Contains(u.RolId))
            .ToListAsync();

        _context.Usuario.RemoveRange(usuarios);
        await _context.SaveChangesAsync();
    }

    public async Task AgregarRolesUsuarioAsync(Usuario usuarioBase, List<int> rolesAAgregar)
    {
        foreach (var rolId in rolesAAgregar)
        {
            var nuevoUsuario = new Usuario
            {
                Identificacion = usuarioBase.Identificacion,
                NombreUsuario = usuarioBase.NombreUsuario,
                Password = usuarioBase.Password,
                Estado = usuarioBase.Estado,
                RolId = rolId
            };

            await _context.Usuario.AddAsync(nuevoUsuario);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ResetPasswordAsync(string identificacion, string nuevaPassword)
    {
        var usuario = await _context.Usuarios
    .FirstOrDefaultAsync(u => u.Identificacion == identificacion);

        if (usuario == null)
        {
            throw new KeyNotFoundException("El usuario no existe.");
        }

        usuario.Password = Encrypt.EncriptarContrasena(nuevaPassword);

        _context.Entry(usuario).Property(u => u.Password).IsModified = true;
        await _context.SaveChangesAsync();

        return true;
    }

}