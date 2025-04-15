namespace MedicalWeb.BE.Transversales.Entidades
{
    public class MedicoPacienteDTO
    {
        public MedicoInfoDTO Medico { get; set; }
        public PacienteInfoDTO Paciente { get; set; }
    }

    public class MedicoInfoDTO
    {
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Nacionalidad { get; set; }
        public string MatriculaProfesional { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Especialidad { get; set; } 
    }

    public class PacienteInfoDTO
    {
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public string GrupoSanguineo { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Direccion { get; set; }
    }
}