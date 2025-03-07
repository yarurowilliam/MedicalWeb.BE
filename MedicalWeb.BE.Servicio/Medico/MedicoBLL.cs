using MedicalWeb.BE.Infraestructura.Image;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Transversales.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MedicalWeb.BE.Servicio;

public class MedicoBLL : IMedicoBLL
{
    private readonly IMedicoDAL _medicoDAL;
    private readonly ICloudinaryService _cloudinaryService;

    public MedicoBLL(IMedicoDAL medicoDAL, ICloudinaryService cloudinaryService)
    {
        _medicoDAL = medicoDAL;
        _cloudinaryService = cloudinaryService;
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
            Estado = medico.Estado,
            ImagenUrl = medico.ImagenUrl
        };
    }

    public static IEnumerable<MedicoDTO> MapToDTO(IEnumerable<Medico> medicos)
    {
        return medicos.Select(MapToDTO);
    }

    public async Task<MedicoDTO> GetByIdAsync(string id)
    {
        var medico = await _medicoDAL.GetByIdAsync(id);
        return MapToDTO(medico);
    }

    public async Task<Medico> InsertAsync(MedicoDTO medicoDTO)
    {
        string imagenUrl = null;
        if (medicoDTO.ImagenFile != null)
        {
            imagenUrl = await _cloudinaryService.SubirImagenAsync(medicoDTO.ImagenFile);
        }

        var medico = new Medico
        {
            TipoDocumento = int.Parse(medicoDTO.TipoDocumento),
            NumeroDocumento = medicoDTO.NumeroDocumento,
            PrimerNombre = medicoDTO.PrimerNombre,
            SegundoNombre = medicoDTO.SegundoNombre,
            PrimerApellido = medicoDTO.PrimerApellido,
            SegundoApellido = medicoDTO.SegundoApellido,
            CorreoElectronico = medicoDTO.CorreoElectronico,
            Telefono = medicoDTO.Telefono,
            Celular = medicoDTO.Celular,
            Direccion = medicoDTO.Direccion,
            Ciudad = medicoDTO.Ciudad, 
            Departamento = medicoDTO.Departamento,
            Pais = medicoDTO.Pais,
            CodigoPostal = medicoDTO.CodigoPostal,
            Genero = medicoDTO.Genero,
            EstadoCivil = medicoDTO.EstadoCivil,
            FechaNacimiento = medicoDTO.FechaNacimiento,
            LugarNacimiento = medicoDTO.LugarNacimiento,
            Nacionalidad = medicoDTO.Nacionalidad,
            MatriculaProfesional = medicoDTO.MatriculaProfesional,
            Universidad = medicoDTO.Universidad,
            AnioGraduacion = medicoDTO.AnioGraduacion,
            FechaIngreso = medicoDTO.FechaIngreso,
            FechaSalida = medicoDTO.FechaSalida,
            Estado = medicoDTO.Estado,
            ImagenUrl = imagenUrl
        };

        return await _medicoDAL.InsertAsync(medico);
    }

    public async Task<Medico> UpdateAsync(MedicoDTO medicoDTO)
    {
        var medicoExistente = await _medicoDAL.GetByIdAsync(medicoDTO.NumeroDocumento);
        if (medicoExistente == null)
        {
            throw new Exception("El médico no existe");
        }

        if (medicoDTO.ImagenFile != null)
        {
            medicoExistente.ImagenUrl = await _cloudinaryService.SubirImagenAsync(medicoDTO.ImagenFile);
        }

        medicoExistente.PrimerNombre = medicoDTO.PrimerNombre;
        medicoExistente.SegundoNombre = medicoDTO.SegundoNombre;
        medicoExistente.PrimerApellido = medicoDTO.PrimerApellido;
        medicoExistente.SegundoApellido = medicoDTO.SegundoApellido;
        medicoExistente.CorreoElectronico = medicoDTO.CorreoElectronico;
        medicoExistente.Telefono = medicoDTO.Telefono;
        medicoExistente.Celular = medicoDTO.Celular;
        medicoExistente.Direccion = medicoDTO.Direccion;
        medicoExistente.Ciudad = medicoDTO.Ciudad;
        medicoExistente.Departamento = medicoDTO.Departamento;
        medicoExistente.Pais = medicoDTO.Pais;
        medicoExistente.CodigoPostal = medicoDTO.CodigoPostal;
        medicoExistente.Genero = medicoDTO.Genero;
        medicoExistente.EstadoCivil = medicoDTO.EstadoCivil;
        medicoExistente.FechaNacimiento = medicoDTO.FechaNacimiento;
        medicoExistente.LugarNacimiento = medicoDTO.LugarNacimiento;
        medicoExistente.Nacionalidad = medicoDTO.Nacionalidad;
        medicoExistente.MatriculaProfesional = medicoDTO.MatriculaProfesional;
        medicoExistente.Universidad = medicoDTO.Universidad;
        medicoExistente.AnioGraduacion = medicoDTO.AnioGraduacion;
        medicoExistente.FechaIngreso = medicoDTO.FechaIngreso;
        medicoExistente.FechaSalida = medicoDTO.FechaSalida;
        medicoExistente.Estado = medicoDTO.Estado;

        return await _medicoDAL.UpdateAsync(medicoExistente);
    }
}