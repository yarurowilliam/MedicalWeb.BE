using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using System.Threading.Tasks;
namespace MedicalWeb.BE.Repositorio.Interfaces;

public interface IUsuarioDAL
{
    Task<IEnumerable<Usuario>> GetUsuarioAsync();
    Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(string id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(string id);
    Task<IEnumerable<Usuario>> GetUsuarioByCredentialsAsync(string nombreUsuario, string passwordEncriptada);
}