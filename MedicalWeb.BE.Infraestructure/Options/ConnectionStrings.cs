namespace MedicalWeb.BE.Infraestructure.Options;

public record ConnectionStrings
{
    public string Database { get; set; } = default!;
    public string StorageAccount { get; set; } = default!;
}
