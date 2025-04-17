using Microsoft.AspNetCore.Http;

namespace MedicalWeb.BE.Repositorio.Interfaces
{
    public interface IFileStorageDAL
    {
        Task<string> UploadFileAsync(IFormFile file, string path, CancellationToken cancellationToken);
        Task<List<string>> GetFilesAsync(string directory, CancellationToken cancellationToken);

    }
}