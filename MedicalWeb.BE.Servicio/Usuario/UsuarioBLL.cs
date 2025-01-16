using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio;

public class UsuarioBLL : IUsuarioBLL
{
    private readonly IUsuarioDAL _usuarioDAL;
    
    public UsuarioBLL(IUsuarioDAL usuarioDAL)
    {
        _usuarioDAL = usuarioDAL;
    }

    public static UsuarioDTO MapToDTO(Usuario usuario)
    {
        return new UsuarioDTO
        {
            Identificacion = usuario.Identificacion,
            NombreUsuario = usuario.NombreUsuario,
            Password = usuario.Password,
            Estado = Convert.ToString(usuario.Estado),
            RolId = Rol.GetRolById(usuario.RolId).Nombre,
        };
    }

    public static IEnumerable<UsuarioDTO> MapToDTO(IEnumerable<Usuario> usuario)
    {
        return usuario.Select(MapToDTO);
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.CreateUsuarioAsync(usuario);
    }

    public async Task DeleteUsuarioAsync(string id)
    {
        await _usuarioDAL.DeleteUsuarioAsync(id);
    }

    public async Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync()
    {
        var usuario = await _usuarioDAL.GetUsuarioAsync();
        return MapToDTO(usuario);
    }

    public async Task<UsuarioDTO> GetUsuarioByIdAsync(string id)
    {
        var usuario = await _usuarioDAL.GetUsuarioByIdAsync(id);
        return MapToDTO(usuario);
    }

    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.UpdateUsuarioAsync(usuario);
    }
}