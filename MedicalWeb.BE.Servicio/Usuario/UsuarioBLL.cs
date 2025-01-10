using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using System;
namespace MedicalWeb.BE.Servicio;

public class UsuarioBLL : IUsuarioBLL
{
    private readonly IUsuarioDAL _usuarioDAL;
    
    public UsuarioBLL(IUsuarioDAL usuarioDAL)
    {
        _usuarioDAL = usuarioDAL;
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.CreateUsuarioAsync(usuario);
    }

    public async Task DeleteUsuarioAsync(string id)
    {
        await _usuarioDAL.DeleteUsuarioAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
        return await _usuarioDAL.GetUsuarioAsync();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(string id)
    {
        return await _usuarioDAL.GetUsuarioByIdAsync(id);
    }

    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioDAL.UpdateUsuarioAsync(usuario);
    }
}