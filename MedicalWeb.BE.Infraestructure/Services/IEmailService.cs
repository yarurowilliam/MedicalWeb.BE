namespace MedicalWeb.BE.Infraestructure.Services;

public interface IEmailService
{
    Task SendEmailAsync(IEmailInfo emailInfo, CancellationToken cancellationToken);
}
