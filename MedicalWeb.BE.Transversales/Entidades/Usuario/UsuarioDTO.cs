using System.Text.Json.Serialization;
namespace MedicalWeb.BE.Transversales.Entidades;

public class UsuarioDTO
{
    [JsonIgnore]
    public int UsuarioID { get; set; }
    public string Identificacion { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public char Estado { get; set; }
    public string RolId{ get; set; }
    public string Correos { get; set; }
}