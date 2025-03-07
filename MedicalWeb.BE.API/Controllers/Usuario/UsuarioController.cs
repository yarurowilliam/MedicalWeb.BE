﻿using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = MedicalWeb.BE.Transversales.Entidades.LoginRequest;

namespace MedicalWeb.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBLL _usuarioBLL;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioBLL usuarioBLL, IConfiguration configuration)
        {
            _usuarioBLL = usuarioBLL;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync()
        {
            return await _usuarioBLL.GetUsuarioAsync();
        }

        [HttpGet("detail/{id}")]
        public async Task<IEnumerable<UsuarioDTO>> GetUsuarioByIdAsync(string id)
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var token = await _usuarioBLL.LoginAsync(loginRequest.NombreUsuario, loginRequest.Password, _configuration);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Credenciales incorrectas.");
                }

                return Ok(new
                {
                    token = token
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("ActualizarRoles")]
        public async Task<IActionResult> ActualizarRoles([FromBody] ActualizarRolesDTO request)
        {
            var resultado = await _usuarioBLL.ActualizarRolesUsuarioAsync(request.Identificacion, request.NuevosRoles);

            if (!resultado)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            return Ok(new { mensaje = "Roles actualizados correctamente" });
        }

        [HttpPatch("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Identificacion) || string.IsNullOrWhiteSpace(dto.NuevaPassword))
            {
                return BadRequest("Los datos de entrada son inválidos.");
            }

            var resultado = await _usuarioBLL.ResetPasswordAsync(dto);
            if (!resultado)
            {
                return NotFound("No se pudo restablecer la contraseña.");
            }

            return Ok("Contraseña restablecida con éxito.");
        }

    }
}