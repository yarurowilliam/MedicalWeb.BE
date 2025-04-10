﻿using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using MedicalWeb.BE.Transversales;
using MedicalWeb.BE.Servicio.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MedicalWeb.BE.Infraestructure.Options;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MedicalWeb.BE.Servicio
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body, IFormFile? attachment = null, CancellationToken cancellationToken = default)
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

            // Verificar si hay un archivo adjunto
            if (attachment != null && attachment.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await attachment.CopyToAsync(memoryStream, cancellationToken);
                var attachmentData = new Attachment(new MemoryStream(memoryStream.ToArray()), attachment.FileName);
                mail.Attachments.Add(attachmentData);
            }

            await smtp.SendMailAsync(mail, cancellationToken);
        }
    }
}