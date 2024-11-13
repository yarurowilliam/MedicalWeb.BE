namespace MedicalWeb.BE.Transversales
{
    public sealed class DocumentationStatus
    {
        public static readonly DocumentationStatus Incompleted = new(1, DocumentationStatuses.Incompleted);
        public static readonly DocumentationStatus ValidationPending = new(2, DocumentationStatuses.ValidationPending);
        public static readonly DocumentationStatus Validated = new(3, DocumentationStatuses.Validated);

        public static class DocumentationStatuses
        {
            public const string Incompleted = "INCOMPLETED";
            public const string ValidationPending = "VALIDATION_PENDING";
            public const string Validated = "VALIDATED";

        }

        public int Id { get; }
        public string Code { get; }

        private DocumentationStatus(int id, string code)
        {
            Id = id;
            Code = code;
        }

        private DocumentationStatus() { }

        public static DocumentationStatus[] GetAll()
            => new[] {
                Incompleted,
                ValidationPending,
                Validated
            };

        public static DocumentationStatus GetById(int id)
            => GetAll().First(x => x.Id == id);

        public static DocumentationStatus GetByCode(string code)
            => GetAll().First(x => x.Code == code);

        public static bool IsValidCode(string code)
            => GetAll().Any(x => x.Code == code);

    }
}
