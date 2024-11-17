namespace MedicalWeb.BE.Transversales
{   
    public sealed class EstadoHorarioMedico
    {
        public static readonly EstadoHorarioMedico Disponible = new(1, EstadoHorarioMedicos.Disponible);
        public static readonly EstadoHorarioMedico NoDisponible = new(2, EstadoHorarioMedicos.Ocupado);
        public static readonly EstadoHorarioMedico Ocupado = new(3, EstadoHorarioMedicos.NoDisponible);
        public static class EstadoHorarioMedicos
        {
            public const string Disponible = "DISPONIBLE";
            public const string Ocupado = "OCUPADO";
            public const string NoDisponible = "NO DISPONIBLE";
        }

        public int EstadoHorarioID { get; }

        public string Code { get; } 

        private EstadoHorarioMedico(int EstadoHorarioid, string code)
        {   
            EstadoHorarioID = EstadoHorarioid;
            Code = code;
        }

        private EstadoHorarioMedico() { }

        public static EstadoHorarioMedico[] GetAll()
            => new[] {
            Disponible,
            Ocupado,
            NoDisponible
            };

        public static EstadoHorarioMedico GetById(int id)
            => GetAll().First(x => x.EstadoHorarioID == id);

        public static EstadoHorarioMedico GetByCode(string code)
            => GetAll().First(x => x.Code == code);

        public static bool IsValidCode(string code)
            => GetAll().Any(x => x.Code == code);
    }
}