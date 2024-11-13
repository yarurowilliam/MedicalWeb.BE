namespace MedicalWeb.BE.Infraestructure.Services;

public interface IEmailInfo
{
    string RecipientEmail { get; }
    string Subject { get; }

    string GetHtmlContent();
}


