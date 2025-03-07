using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.Extensions.Configuration;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IUsuarioBLL
{
    Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync();
    Task<IEnumerable<UsuarioDTO>> GetUsuarioByIdAsync(string id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);  
    Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(string id);
    Task<string> LoginAsync(string nombreUsuario, string password, IConfiguration config);
    Task<bool> ActualizarRolesUsuarioAsync(string identificacion, List<int> nuevosRoles);
}