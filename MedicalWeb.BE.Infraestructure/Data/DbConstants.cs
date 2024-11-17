namespace MedicalWeb.BE.Infraestructure.Data;

public static class DbConstants
{
    public const string DateTime2 = "datetime2(7)";
    public const string EstateId = nameof(EstateId);
    public const string TradingCompanyId = nameof(TradingCompanyId);
    public const string Discriminator = nameof(Discriminator);
    public const string FULL = nameof(FULL);
    public const string MINIMAL = nameof(MINIMAL);

    public static class Schemas
    {
        public const string Dbo = "dbo";
        public const string Test = "test";
    }

    public static class Tables
    {
        public const string Medicos = nameof(Medicos);
        public const string Usuarios = nameof(Usuarios);
        public const string DocumentationStatuses = nameof(DocumentationStatuses);
        public const string NotificationMethods = nameof(NotificationMethods);
        public const string Especialidades = nameof(Especialidades);
        public const string MedicoEspecialidad = nameof(MedicoEspecialidad);
        public const string EFMigrationsHistory = $"_{nameof(EFMigrationsHistory)}_";
    }

    public static class Sequences
    {
        private const string Prefix = "Seq";
    }

    public static class StringLength
    {
        public const int Names = 250;
        public const int Email = 320;
        public const int Phone = 15;
        public const int Province = 100;
        public const int IdentificationNumber = 10;
        public const int Code = 250;
        public const int Address = 200;
        public const int FullAddress = 500;
        public const int PostalCode = 10;
        public const int MasterNames = 50;
        public const int EstateCode = 20;
        public const int EstateCadastralReference = 20;
        public const int EstateRecordCode = 36;
        public const int EstateClientId = 100;
        public const int Observations = 500;
        public const int StreetNumber = 5;
        public const int Staircase = 5;
        public const int Floor = 3;
        public const int Token = 32;
        public const int Description = 300;
    }

    public class ShadowProperties
    {
        public const string CreatedBy = nameof(CreatedBy);
        public const string CreatedDate = nameof(CreatedDate);
        public const string UpdatedBy = nameof(UpdatedBy);
        public const string UpdatedDate = nameof(UpdatedDate);
        public const string IsDeleted = nameof(IsDeleted);
        public const string DeletedBy = nameof(DeletedBy);
        public const string DeletedDate = nameof(DeletedDate);
        public const int CreatedByLength = 50;
        public const int UpdatedByLength = 50;
        public const int DeletedByLength = 50;
    }

    public class PaymentTokenProperties
    {
        public const int TokenSizeInBytes = 24;
        public const int TokenExpirationDays = 2;
    }

    public class EstateRecordTokenProperties
    {
        public const int TokenSizeInBytes = 24;
        public const int TokenExpirationDays = 2;
    }
}
