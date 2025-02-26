using Microsoft.AspNetCore.Http;
namespace MedicalWeb.BE.Transversales;

public class EmailRequest
{
    public string To { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string Body { get; set; } = default!;
    public IFormFile? Attachment { get; set; }
}