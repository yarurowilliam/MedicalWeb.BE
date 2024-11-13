namespace MedicalWeb.BE.Infraestructure.Options;

public record AzureCommunicationService
{
    public string ConnectionString { get; set; } = default!;
}