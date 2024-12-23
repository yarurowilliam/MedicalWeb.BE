namespace MedicalWeb.BE.Transversales.Entidades;

public class Medicion
{
    public int Id { get; set; }
    public string NumeroDocumento { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public DateTime FechaRegistro { get; set; }

    // Relación con paciente
    public Pacientes Paciente { get; set; }
}