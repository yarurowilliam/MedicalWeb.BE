namespace MedicalWeb.BE.Transversales
{   
    public sealed class EstadoHorarioMedico
    {
        public static readonly EstadoHorarioMedico Disponible = new(1, EstadoHorarioMedicos.Pendiente);
        public static readonly EstadoHorarioMedico NoDisponible = new(2, EstadoHorarioMedicos.Vencida);
        public static readonly EstadoHorarioMedico Ocupado = new(3, EstadoHorarioMedicos.EnCurso);
        public static readonly EstadoHorarioMedico Cancelada = new(4, EstadoHorarioMedicos.Cancelada);
        public static class EstadoHorarioMedicos
        {
            public const string Pendiente = "PENDIENTE";
            public const string Vencida = "VENCIDA";
            public const string EnCurso = "EN CURSO";
            public const string Cancelada = "CANCELADA";
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
            NoDisponible,
            Cancelada
            };

        public static EstadoHorarioMedico GetById(int id)
            => GetAll().First(x => x.EstadoHorarioID == id);

        public static EstadoHorarioMedico GetByCode(string code)
            => GetAll().First(x => x.Code == code);

        public static bool IsValidCode(string code)
            => GetAll().Any(x => x.Code == code);
    }
}