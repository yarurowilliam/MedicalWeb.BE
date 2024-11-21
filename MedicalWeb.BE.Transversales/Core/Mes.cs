namespace MedicalWeb.BE.Transversales.Core
{
    public sealed class Mes
    {

        public static readonly Mes Enero = new(1, NombresMes.Enero);
        public static readonly Mes Febrero = new(2, NombresMes.Febrero);
        public static readonly Mes Marzo = new(3, NombresMes.Marzo);
        public static readonly Mes Abril = new(4, NombresMes.Abril);
        public static readonly Mes Mayo = new(5, NombresMes.Mayo);
        public static readonly Mes Junio = new(6, NombresMes.Junio);
        public static readonly Mes Julio = new(7, NombresMes.Julio);
        public static readonly Mes Agosto = new(8, NombresMes.Agosto);
        public static readonly Mes Septiembre = new(9, NombresMes.Septiembre);
        public static readonly Mes Octubre = new(10, NombresMes.Octubre);
        public static readonly Mes Noviembre = new(11, NombresMes.Noviembre);
        public static readonly Mes Diciembre = new(12, NombresMes.Diciembre);

        public static class NombresMes      
        {
            public const string Enero = "ENERO";
            public const string Febrero = "FEBRERO";
            public const string Marzo = "MARZO";
            public const string Abril = "ABRIL";
            public const string Mayo = "MAYO";
            public const string Junio = "JUNIO";
            public const string Julio = "JULIO";
            public const string Agosto = "AGOSTO";
            public const string Septiembre = "SEPTIEMBRE";
            public const string Octubre = "OCTUBRE";
            public const string Noviembre = "NOVIEMBRE";
            public const string Diciembre = "DICIEMBRE";
        }

        public int MesID { get; }
        public string Code { get; }
        
        private Mes (int id, string code)
        {
            MesID = id;
            Code = code;
        }

        private Mes() { }

        public static Mes[] GetAll()
                => new[] {
                Enero,
                Febrero,
                Marzo,
                Abril,
                Mayo,
                Junio,
                Julio,
                Agosto,
                Septiembre,
                Octubre,
                Noviembre,
                Diciembre
                };

            public static Mes GetById(int id)
                => GetAll().First(x => x.MesID == id);

            public static Mes GetByNombre(string nombre)
                => GetAll().First(x => x.Code == nombre);

            public static bool IsValidNombre(string nombre)
                => GetAll().Any(x => x.Code == nombre);
    }
}