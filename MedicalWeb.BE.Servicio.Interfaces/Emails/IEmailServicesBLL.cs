using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Servicio.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, IFormFile? attachment = null, CancellationToken cancellationToken = default);
    }
}