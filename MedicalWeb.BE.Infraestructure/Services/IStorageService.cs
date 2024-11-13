namespace MedicalWeb.BE.Infraestructure.Services
{
    public interface IStorageService
    {
        Task CreateContainerAsync(string containerName, CancellationToken cancellationToken = default);
        Task<bool> ExistsBlobAsync(string containerName, string fileName, CancellationToken cancellationToken = default);
        Task<string> UploadFileAsync(string containerName, string fileName, Stream fileContent, string contentType = "application/octet-stream", CancellationToken cancellationToken = default);
        Task<bool> DeleteFileAsync(string containerName, string blobName, CancellationToken cancellationToken = default);
        Task<BlobFile?> DownloadBlobAsync(string containerName, string blobName, CancellationToken cancellationToken = default);
        Task DeleteContainerAsync(string containerName);
        string? CreateUriSASTokenForBlobRead(string containerName, string uniqueName);
    }
}