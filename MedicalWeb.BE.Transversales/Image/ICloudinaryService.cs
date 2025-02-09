using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MedicalWeb.BE.Transversales.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> SubirImagenAsync(IFormFile file);
    }
}