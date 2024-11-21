namespace MedicalWeb.BE.Transversales
{
    public sealed class HorasMedicas
    {
        public static readonly HorasMedicas SeisAM = new(1, NombreHoras.SeisAM);
        public static readonly HorasMedicas SieteAM = new(2, NombreHoras.SieteAM);
        public static readonly HorasMedicas OchoAM = new(3, NombreHoras.OchoAM);
        public static readonly HorasMedicas NueveAM = new(4, NombreHoras.NueveAM);
        public static readonly HorasMedicas DiezAM = new(5, NombreHoras.DiezAM);
        public static readonly HorasMedicas OnceAM = new(6, NombreHoras.OnceAM);
        public static readonly HorasMedicas DocePM = new(7, NombreHoras.DocePM);
        public static readonly HorasMedicas UnaPM = new(8, NombreHoras.UnaPM);
        public static readonly HorasMedicas DosPM = new(9, NombreHoras.DosPM);
        public static readonly HorasMedicas TresPM = new(10, NombreHoras.TresPM);
        public static readonly HorasMedicas CuatroPM = new(11, NombreHoras.CuatroPM);
        public static readonly HorasMedicas CincoPM = new(12, NombreHoras.CincoPM);
        public static readonly HorasMedicas SeisPM = new(13, NombreHoras.SeisPM);

        public static class NombreHoras
        {
            public const string SeisAM = "6:00 AM";
            public const string SieteAM = "7:00 AM";
            public const string OchoAM = "8:00 AM";
            public const string NueveAM = "9:00 AM";
            public const string DiezAM = "10:00 AM";
            public const string OnceAM = "11:00 AM";
            public const string DocePM = "12:00 PM";
            public const string UnaPM = "1:00 PM";
            public const string DosPM = "2:00 PM";
            public const string TresPM = "3:00 PM";
            public const string CuatroPM = "4:00 PM";
            public const string CincoPM = "5:00 PM";
            public const string SeisPM = "6:00 PM";
        }

        public int HoraMedicaID { get; }
        public string Code { get; }

        public HorasMedicas(int id, string code)
        {
            HoraMedicaID = id;
            Code = code;
        }

        public HorasMedicas () { }

        public static HorasMedicas[] GetAll()
            => new[] {
                SeisAM,
                SieteAM,
                OchoAM,
                NueveAM,
                DiezAM,
                OnceAM,
                DocePM,
                UnaPM,
                DosPM,
                TresPM,
                CuatroPM,
                CincoPM,
                SeisPM
            };
        public static HorasMedicas GetById (int id)
            => GetAll().First(x => x.HoraMedicaID == id);

        public static HorasMedicas GetByNombre (string nombre)
            => GetAll().First(x => x.Code == nombre);
        public static bool IsValidNombre(string nombre)
            => GetAll().Any(x => x.Code == nombre);
    }
}