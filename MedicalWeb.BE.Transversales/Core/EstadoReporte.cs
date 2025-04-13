namespace MedicalWeb.BE.Transversales
{
    public sealed class EstadoReporte
    {
        public static readonly EstadoReporte Pendiente = new(1, EstadoReportes.Pendiente);
        public static readonly EstadoReporte Resuelto = new(2, EstadoReportes.Resuelto);
        public static readonly EstadoReporte Rechazado = new(3, EstadoReportes.Rechazado);

        public static class EstadoReportes
        {
            public const string Pendiente = "PENDIENTE";
            public const string Resuelto = "RESUELTO";
            public const string Rechazado = "RECHAZADO";
        }

        public int EstadoReporteID { get; }

        public string Code { get; }

        private EstadoReporte(int estadoReporteID, string code)
        {
            EstadoReporteID = estadoReporteID;
            Code = code;
        }

        private EstadoReporte() { }

        public static EstadoReporte[] GetAll()
            => new[] {
                Pendiente,
                Resuelto,
                Rechazado
            };

        public static EstadoReporte GetById(int id)
            => GetAll().First(x => x.EstadoReporteID == id);

        public static EstadoReporte GetByCode(string code)
            => GetAll().First(x => x.Code == code);

        public static bool IsValidCode(string code)
            => GetAll().Any(x => x.Code == code);
    }
}