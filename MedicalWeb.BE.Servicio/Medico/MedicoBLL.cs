using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;

namespace MedicalWeb.BE.Servicio;

public class MedicoBLL : IMedicoBLL
{
    private readonly IMedicoDAL _medicoDAL;

    public MedicoBLL(IMedicoDAL medicoDAL)
    {
        _medicoDAL = medicoDAL;
    }

    public async Task DeleteAsync(string id)
    {
        await _medicoDAL.DeleteAsync(id);
    }

    public async Task<IEnumerable<MedicoDTO>> GetAllAsync()
    {
        var medicos = await _medicoDAL.GetAllAsync();
        return MapToDTO(medicos);
    }

    public static MedicoDTO MapToDTO(Medico medico)
    {
        return new MedicoDTO
        {
            TipoDocumento = Transversales.TipoDocumento.GetById(medico.TipoDocumento).Name,
            NumeroDocumento = medico.NumeroDocumento,
            PrimerNombre = medico.PrimerNombre,
            SegundoNombre = medico.SegundoNombre,
            PrimerApellido = medico.PrimerApellido,
            SegundoApellido = medico.SegundoApellido,
            CorreoElectronico = medico.CorreoElectronico,
            Telefono = medico.Telefono,
            Celular = medico.Celular,
            Direccion = medico.Direccion,
            Ciudad = medico.Ciudad,
            Departamento = medico.Departamento,
            Pais = medico.Pais,
            CodigoPostal = medico.CodigoPostal,
            Genero = medico.Genero,
            EstadoCivil = medico.EstadoCivil,
            FechaNacimiento = medico.FechaNacimiento,
            LugarNacimiento = medico.LugarNacimiento,
            Nacionalidad = medico.Nacionalidad,
            MatriculaProfesional = medico.MatriculaProfesional,
            Universidad = medico.Universidad,
            AnioGraduacion = medico.AnioGraduacion,
            FechaIngreso = medico.FechaIngreso,
            FechaSalida = medico.FechaSalida,
            Estado = medico.Estado
        };
    }

    public static IEnumerable<MedicoDTO> MapToDTO(IEnumerable<Medico> medicos)
    {
        return medicos.Select(MapToDTO);
    }


    public async Task<MedicoDTO> GetByIdAsync(string id)
    {
        var medicos = await _medicoDAL.GetByIdAsync(id);
        return MapToDTO(medicos);
    }

    public async Task<Medico> InsertAsync(Medico medico)
    {
        return await _medicoDAL.InsertAsync(medico);
    }

    public async Task<Medico> UpdateAsync(Medico medico)
    {
        return await _medicoDAL.UpdateAsync(medico);
    }
}