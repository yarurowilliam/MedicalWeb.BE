using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Encriptacion;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.Extensions.Configuration;
using Auth0.ManagementApi.Models;
namespace MedicalWeb.BE.Servicio;

public class UsuarioBLL : IUsuarioBLL
{
    private readonly IUsuarioDAL _usuarioDAL;
    private readonly IConfiguration _configuration;

    public UsuarioBLL(IUsuarioDAL usuarioDAL, IConfiguration configuration)
    {
        _usuarioDAL = usuarioDAL;
        _configuration = configuration;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetUsuarioByIdAsync(string id)
    {
        var usuarios = await _usuarioDAL.GetUsuarioByIdAsync(id);

        var usuariosDTO = usuarios.Select(u => new UsuarioDTO
        {
            UsuarioID = u.UsuarioID,
            Identificacion = u.Identificacion,
            NombreUsuario = u.NombreUsuario,
            Password = u.Password,
            Estado = u.Estado,
            RolId = Rol.GetRolById(u.RolId)?.Nombre
        }).ToList();

        return usuariosDTO;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync()
    {
        var usuarios = await _usuarioDAL.GetUsuarioAsync();

        var usuariosDTO = usuarios
            .GroupBy(u => u.Identificacion)  
            .Select(g => new UsuarioDTO
            {
                UsuarioID = g.First().UsuarioID,  
                Identificacion = g.Key,
                NombreUsuario = g.First().NombreUsuario,  
                Password = g.First().Password, 
                Estado = g.First().Estado,  
                RolId = string.Join(", ", g.Select(u => Rol.GetRolById(u.RolId)?.Nombre ?? "Desconocido"))  
            })
            .ToList();

        return usuariosDTO;
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.CreateUsuarioAsync(usuario);
    }

    public async Task DeleteUsuarioAsync(string id)
    {
        await _usuarioDAL.DeleteUsuarioAsync(id);
    }

    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.UpdateUsuarioAsync(usuario);
    }

    public async Task<string> LoginAsync(string nombreUsuario, string password, IConfiguration config)
    {

        string passwordEncriptada = Encrypt.EncriptarContrasena(password);

        var usuarios = await _usuarioDAL.GetUsuarioByCredentialsAsync(nombreUsuario, passwordEncriptada);

        if (usuarios == null || !usuarios.Any())
        {
            throw new UnauthorizedAccessException("Credenciales incorrectas.");
        }

        if (usuarios.Any(u => u.Estado != 'A'))
        {
            throw new UnauthorizedAccessException("El usuario no está activo.");
        }

        var usuarioBase = usuarios.First();
        var rolesCombinados = string.Join(",", usuarios.Select(u => Rol.GetRolById(u.RolId)?.Nombre ?? "Desconocido"));

        var usuarioDTO = new UsuarioDTO
        {
            Identificacion = usuarioBase.Identificacion,
            NombreUsuario = usuarioBase.NombreUsuario,
            RolId = rolesCombinados
        };

        return Transversales.Encriptacion.JwtConfiguration.GetToken(usuarioDTO, config);
    }

    public async Task<bool> ActualizarRolesUsuarioAsync(string identificacion, List<int> nuevosRoles)
    {
        // Obtener todos los usuarios con la misma Identificación
        var usuariosExistentes = await _usuarioDAL.ObtenerUsuariosPorIdentificacionAsync(identificacion);

        if (!usuariosExistentes.Any())
            return false; 

        var rolesActuales = usuariosExistentes.Select(u => u.RolId).ToList();

        // Determinar roles a eliminar (los que ya no están en la nueva lista)
        var rolesAEliminar = rolesActuales.Except(nuevosRoles).ToList();

        // Determinar roles a agregar (los nuevos que antes no estaban)
        var rolesAAgregar = nuevosRoles.Except(rolesActuales).ToList();

        // Eliminar solo los registros con roles obsoletos
        if (rolesAEliminar.Any())
            await _usuarioDAL.EliminarRolesUsuarioAsync(identificacion, rolesAEliminar);

        // Agregar nuevos roles sin perder la información del usuario
        if (rolesAAgregar.Any())
        {
            var usuarioBase = usuariosExistentes.First(); // Tomamos un usuario de referencia para mantener los datos
            await _usuarioDAL.AgregarRolesUsuarioAsync(usuarioBase, rolesAAgregar);
        }

        return true; // Operación exitosa
    }

}