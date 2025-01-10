using MedicalWeb.BE.Transversales;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IUsuarioDAL
{
    Task<IEnumerable<Usuario>> GetUsuarioAsync();
    Task<Usuario> GetUsuarioByIdAsync(string id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(string id);
}