﻿using Microsoft.AspNetCore.Http;
namespace MedicalWeb.BE.Transversales.Entidades;

public class MedicoDTO
{
    public string TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }
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
    public string FechaNacimiento { get; set; }
    public string LugarNacimiento { get; set; }
    public string Nacionalidad { get; set; }
    public string MatriculaProfesional { get; set; }
    public string Universidad { get; set; }
    public string AnioGraduacion { get; set; }
    public string FechaIngreso { get; set; }
    public string FechaSalida { get; set; }
    public string Estado { get; set; }
    public string? ImagenUrl { get; set; } 
    public IFormFile? ImagenFile { get; set; } 
}