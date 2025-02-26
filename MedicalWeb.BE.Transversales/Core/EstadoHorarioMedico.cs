namespace MedicalWeb.BE.Transversales
{   
    public sealed class EstadoHorarioMedico
    {
        public static readonly EstadoHorarioMedico Pendiente = new(1, EstadoHorarioMedicos.Pendiente);
        public static readonly EstadoHorarioMedico Completada = new(2, EstadoHorarioMedicos.Completada);
        public static readonly EstadoHorarioMedico Ocupado = new(3, EstadoHorarioMedicos.EnCurso);
        public static readonly EstadoHorarioMedico Cancelada = new(4, EstadoHorarioMedicos.Cancelada);
        
        public static class EstadoHorarioMedicos
        {
            public const string Pendiente = "PENDIENTE";
            public const string Completada = "COMPLETADA";
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
            Pendiente,
            Ocupado,
            Completada,
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