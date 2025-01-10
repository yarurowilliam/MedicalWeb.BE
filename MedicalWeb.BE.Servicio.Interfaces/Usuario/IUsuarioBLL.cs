using MedicalWeb.BE.Transversales;
namespace MedicalWeb.BE.Servicio.Interfaces;

public interface IUsuarioBLL
{
    Task<IEnumerable<Usuario>> GetUsuarioAsync();
    Task<Usuario> GetUsuarioByIdAsync(string id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync (string id);
}