using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Servicio.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MedicalWeb.BE.Infraestructure.Options;

namespace MedicalWeb.BE.Servicio
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
        {

            using var smtp = new SmtpClient(_emailSettings.SmtpServer)
            {
                Port = _emailSettings.SmtpPort,
                Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword),
                EnableSsl = _emailSettings.EnableSSL
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(to);
            await smtp.SendMailAsync(mail, cancellationToken);
        }
    }
}