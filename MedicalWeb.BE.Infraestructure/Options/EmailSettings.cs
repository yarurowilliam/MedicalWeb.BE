namespace MedicalWeb.BE.Infraestructure.Options;

public record EmailSettings
{
    public string RecipientEmail { get; set; } = default!;
    public string SenderAddress { get; set; } = default!;
    public string PaymentLandingPageUrl { get; set; } = default!;
}
