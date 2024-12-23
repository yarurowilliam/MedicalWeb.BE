﻿namespace MedicalWeb.BE.Transversales.Entidades;

public class PacientesDTO
{
    public string NumeroDocumento { get; set; }
    public string TipoDocumento { get; set; }
    public string PrimerNombre { get; set; }
    public string SegundoNombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
    public string Celular { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Departamento { get; set; }
    public string Pais { get; set; }
    public string CodigoPostal { get; set; }
    public string Genero { get; set; }
    public string EstadoCivil { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string LugarNacimiento { get; set; }
    public string Nacionalidad { get; set; }
    public string GrupoSanguineo { get; set; }
    public bool TieneAlergias { get; set; }
    public string Alergias { get; set; }
    public string Medicamentos { get; set; }
    public string EnfermedadesCronicas { get; set; }
    public string AntecedentesFamiliares { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }

    // Relación con mediciones
    public ICollection<Medicion> Mediciones { get; set; }
}