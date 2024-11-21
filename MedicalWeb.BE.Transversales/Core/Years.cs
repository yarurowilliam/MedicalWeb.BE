namespace MedicalWeb.BE.Transversales.Core
{
    public sealed class Years
    {
        public static readonly Years a2024 = new(1, NombresYears.a2024);
        public static readonly Years a2025 = new(2, NombresYears.a2025);

        public static class NombresYears
        {
            public const string a2024 = "2024";
            public const string a2025 = "2025";
        }

        public int YearsID { get; }
        public string Code { get; }

        private Years(int id, string code)
        {
            YearsID = id;
            Code = code;
        }

        private Years() { }

        public static Years[] GetAll()
                => new[] {
                a2024,
                a2025
                };

        public static Years GetById(int id) 
            => GetAll().First(x => x.YearsID == id);

        public static Years GetByCode(string code)
            => GetAll().First(x => x.Code == code);

        public static bool IsValid(int id)
            => GetAll().Any(x => x.YearsID == id);
    }
}