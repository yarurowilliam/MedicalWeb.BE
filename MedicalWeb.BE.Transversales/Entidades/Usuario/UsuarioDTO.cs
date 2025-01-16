namespace MedicalWeb.BE.Transversales.Entidades;

public class UsuarioDTO
{
    public string Identificacion { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public string Estado { get; set; }
    public string RolId { get; set; }
}