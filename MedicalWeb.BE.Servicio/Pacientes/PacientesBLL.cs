using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using System.Data;
namespace MedicalWeb.BE.Servicio;

public class PacientesBLL : IPacientesBLL
{
    private readonly IPacientesDAL _pacientesDAL;

    public PacientesBLL(IPacientesDAL pacientesDAL)
    {
        _pacientesDAL = pacientesDAL;
    }

    public async Task DeleteAsync(string numeroDocumento)
    {
        await _pacientesDAL.DeleteAsync(numeroDocumento);
    }

    public async Task<IEnumerable<PacientesDTO>> GetAllAsync()
    {
        var pacientes = await _pacientesDAL.GetAllAsync();
        return MapToDTO(pacientes);
    }

    public static PacientesDTO MapToDTO(Pacientes pacientes)
    {
        return new PacientesDTO
        {
            TipoDocumento = Transversales.TipoDocumento.GetById(pacientes.TipoDocumento).Name,
            NumeroDocumento = pacientes.NumeroDocumento,
            PrimerNombre = pacientes.PrimerNombre,
            SegundoNombre = pacientes.SegundoNombre,
            PrimerApellido = pacientes.PrimerApellido,
            SegundoApellido = pacientes.SegundoApellido,
            CorreoElectronico = pacientes.CorreoElectronico,
            Telefono = pacientes.Telefono,
            Celular = pacientes.Celular,
            Direccion = pacientes.Direccion,
            Ciudad = pacientes.Ciudad,
            Departamento = pacientes.Departamento,
            Pais = pacientes.Pais,
            CodigoPostal = pacientes.CodigoPostal,
            Genero = pacientes.Genero,
            EstadoCivil = pacientes.EstadoCivil,
            Peso = pacientes.Peso,
            Altura = pacientes.Altura,
            FechaNacimiento = pacientes.FechaNacimiento,
            LugarNacimiento = pacientes.LugarNacimiento,
            Nacionalidad = pacientes.Nacionalidad,
            GrupoSanguineo = pacientes.GrupoSanguineo,
            TieneAlergias = pacientes.TieneAlergias,
            Alergias = pacientes.Alergias,
            Medicamentos = pacientes.Medicamentos,
            EnfermedadesCronicas = pacientes.EnfermedadesCronicas,
            AntecedentesFamiliares = pacientes.AntecedentesFamiliares,
            FechaRegistro = pacientes.FechaRegistro,
            Estado = pacientes.Estado
        };
    }

    public static IEnumerable<PacientesDTO> MapToDTO(IEnumerable<Pacientes> pacientes)
    {
        return pacientes.Select(MapToDTO);
    }

    public async Task<PacientesDTO> GetByIdAsync(string numeroDocumento)
    {
        var pacientes = await _pacientesDAL.GetByIdAsync(numeroDocumento);
        return MapToDTO(pacientes);
    }

    public async Task<PacientesDTO1> InsertAsync(PacientesDTO1 pacientes)
    {
        return await _pacientesDAL.InsertAsync(pacientes);
    }

    public async Task<PacientesDTO1> UpdateAsync(PacientesDTO1 pacientes)
    {
        return await _pacientesDAL.UpdateAsync(pacientes);
    }
}