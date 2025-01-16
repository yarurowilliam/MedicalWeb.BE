using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IUsuarioBLL
{
    Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync();
    Task<UsuarioDTO> GetUsuarioByIdAsync(string id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync (string id);
}