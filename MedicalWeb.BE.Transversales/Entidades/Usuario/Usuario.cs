namespace MedicalWeb.BE.Transversales;

public class Usuario
{
    public string Identificacion { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public char Estado { get; set; }
    public int RolId { get; set; }
}