using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using Microsoft.AspNetCore.Mvc;
namespace MedicalWeb.BE.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuarioController : ControllerBase
{
    private readonly IUsuarioBLL _usuarioBLL;
    public UsuarioController(IUsuarioBLL usuarioBLL)
    {
        _usuarioBLL = usuarioBLL;
    }
    [HttpGet]
    public async Task<IEnumerable<Usuario>> GetUsuarioAsync()
    {
        return await _usuarioBLL.GetUsuarioAsync();
    }
    [HttpGet("{id}")]
    public async Task<Usuario> GetUsuarioByIdAsync(string id)
    {
        return await _usuarioBLL.GetUsuarioByIdAsync(id);
    }
    [HttpPost]
    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioBLL.CreateUsuarioAsync(usuario);
    }
    [HttpPut]
    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
    {
        return await _usuarioBLL.UpdateUsuarioAsync(usuario);
    }
    [HttpDelete("{id}")]
    public async Task DeleteUsuarioAsync(string id)
    {
        await _usuarioBLL.DeleteUsuarioAsync(id);
    }
}