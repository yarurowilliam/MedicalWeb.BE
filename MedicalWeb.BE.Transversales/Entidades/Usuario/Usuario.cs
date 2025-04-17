using MedicalWeb.BE.Transversales.Entidades;
using System.Text.Json.Serialization;
namespace MedicalWeb.BE.Transversales;

public class Usuario 
{
    [JsonIgnore]
    public int UsuarioID { get; set; } 
    public string Identificacion { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public char Estado { get; set; }
    public int RolId { get; set; }
}