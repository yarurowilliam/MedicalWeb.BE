using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Transversales.Encriptacion;
using MedicalWeb.BE.Transversales.Entidades;
using Microsoft.EntityFrameworkCore;
namespace MedicalWeb.BE.Repositorio;

public class PacientesDAL : IPacientesDAL
{
    private readonly MedicalWebDbContext _context;

    public PacientesDAL(MedicalWebDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(string id)
    {
        var pacientes = await _context.Set<Pacientes>().FindAsync(id);
        if (pacientes != null)
        {
            pacientes.Estado = "I";
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Pacientes>> GetAllAsync()
    {
        return await _context.Set<Pacientes>().ToListAsync();
    }

    public async Task<Pacientes> GetByIdAsync(string numeroDocumento)
    {
        return await _context.Set<Pacientes>().FindAsync(numeroDocumento);
    }

    public async Task<Pacientes> InsertAsync(Pacientes pacientesDto)
    {
        var paciente = new Pacientes
        {
            NumeroDocumento = pacientesDto.NumeroDocumento,
            TipoDocumento = pacientesDto.TipoDocumento,
            PrimerNombre = pacientesDto.PrimerNombre,
            SegundoNombre = pacientesDto.SegundoNombre,
            PrimerApellido = pacientesDto.PrimerApellido,
            SegundoApellido = pacientesDto.SegundoApellido,
            CorreoElectronico = pacientesDto.CorreoElectronico,
            Telefono = pacientesDto.Telefono,
            Celular = pacientesDto.Celular,
            Direccion = pacientesDto.Direccion,
            Ciudad = pacientesDto.Ciudad,
            Departamento = pacientesDto.Departamento,
            Pais = pacientesDto.Pais,
            CodigoPostal = pacientesDto.CodigoPostal,
            Genero = pacientesDto.Genero,
            EstadoCivil = pacientesDto.EstadoCivil,
            Peso = pacientesDto.Peso,
            Altura = pacientesDto.Altura,
            FechaNacimiento = pacientesDto.FechaNacimiento,
            LugarNacimiento = pacientesDto.LugarNacimiento,
            Nacionalidad = pacientesDto.Nacionalidad,
            GrupoSanguineo = pacientesDto.GrupoSanguineo,
            TieneAlergias = pacientesDto.TieneAlergias,
            Alergias = pacientesDto.Alergias,
            Medicamentos = pacientesDto.Medicamentos,
            EnfermedadesCronicas = pacientesDto.EnfermedadesCronicas,
            AntecedentesFamiliares = pacientesDto.AntecedentesFamiliares,
            FechaRegistro = pacientesDto.FechaRegistro,
            Estado = pacientesDto.Estado
        };

        await _context.Pacientes.AddAsync(paciente);

        string nombreUsuario;
        if (string.IsNullOrEmpty(pacientesDto.SegundoNombre))
        {
            nombreUsuario = $"{pacientesDto.PrimerNombre.Substring(0, 2).ToLower()}{pacientesDto.PrimerApellido.ToLower()}";
        }
        else
        {
            nombreUsuario = $"{pacientesDto.PrimerNombre[0]}{pacientesDto.SegundoNombre[0]}{pacientesDto.PrimerApellido}".ToUpper();
        }

        int contador = 1;
        string nombreUsuarioOriginal = nombreUsuario;
        while (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == nombreUsuario))
        {
            nombreUsuario = $"{nombreUsuarioOriginal}{contador}";
            contador++;
        }

        var usuario = new Usuario
        {
            Identificacion = pacientesDto.NumeroDocumento,
            NombreUsuario = nombreUsuario,
            Password = Encrypt.EncriptarContrasena("Medical2024")
        };

        await _context.Set<Usuario>().AddAsync(usuario);
            
        await _context.SaveChangesAsync();
        return pacientesDto;
    }


    public async Task<Pacientes> UpdateAsync(Pacientes pacientesDto)
    {
        var existingPaciente = await _context.Set<Pacientes>().FindAsync(pacientesDto.NumeroDocumento);

        if (existingPaciente != null)
        {
            existingPaciente.TipoDocumento = pacientesDto.TipoDocumento;
            existingPaciente.PrimerNombre = pacientesDto.PrimerNombre;
            existingPaciente.SegundoNombre = pacientesDto.SegundoNombre;
            existingPaciente.PrimerApellido = pacientesDto.PrimerApellido;
            existingPaciente.SegundoApellido = pacientesDto.SegundoApellido;
            existingPaciente.CorreoElectronico = pacientesDto.CorreoElectronico;
            existingPaciente.Telefono = pacientesDto.Telefono;
            existingPaciente.Celular = pacientesDto.Celular;
            existingPaciente.Direccion = pacientesDto.Direccion;
            existingPaciente.Ciudad = pacientesDto.Ciudad;
            existingPaciente.Departamento = pacientesDto.Departamento;
            existingPaciente.Pais = pacientesDto.Pais;
            existingPaciente.CodigoPostal = pacientesDto.CodigoPostal;
            existingPaciente.Genero = pacientesDto.Genero;
            existingPaciente.EstadoCivil = pacientesDto.EstadoCivil;
            existingPaciente.Peso = pacientesDto.Peso;
            existingPaciente.Altura = pacientesDto.Altura;
            existingPaciente.FechaNacimiento = pacientesDto.FechaNacimiento;
            existingPaciente.LugarNacimiento = pacientesDto.LugarNacimiento;
            existingPaciente.Nacionalidad = pacientesDto.Nacionalidad;
            existingPaciente.GrupoSanguineo = pacientesDto.GrupoSanguineo;
            existingPaciente.TieneAlergias = pacientesDto.TieneAlergias;
            existingPaciente.Alergias = pacientesDto.Alergias;
            existingPaciente.Medicamentos = pacientesDto.Medicamentos;
            existingPaciente.EnfermedadesCronicas = pacientesDto.EnfermedadesCronicas;
            existingPaciente.AntecedentesFamiliares = pacientesDto.AntecedentesFamiliares;
            existingPaciente.FechaRegistro = pacientesDto.FechaRegistro;
            existingPaciente.Estado = pacientesDto.Estado;

            await _context.SaveChangesAsync();
        }
        return pacientesDto;
    }
}