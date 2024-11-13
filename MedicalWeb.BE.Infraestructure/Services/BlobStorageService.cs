using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System.Web;

namespace MedicalWeb.BE.Infraestructure.Services;

public class BlobStorageService(BlobServiceClient blobServiceClient) : IStorageService
{
    public async Task CreateContainerAsync(string containerName, CancellationToken cancellationToken = default)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
    }

    public async Task<bool> ExistsBlobAsync(string containerName, string fileName,
        CancellationToken cancellationToken = default)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        return await blobClient.ExistsAsync(cancellationToken);
    }

    public async Task<string> UploadFileAsync(string containerName, string fileName, Stream fileContent, string contentType = "application/octet-stream", CancellationToken cancellationToken = default)
    {
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        // Obtener una referencia al blob donde se subirá el archivo
        BlobClient blobClient = containerClient.GetBlobClient(fileName);

        // Subir el archivo al blob
        await blobClient.UploadAsync(fileContent, new BlobHttpHeaders { ContentType = contentType }, cancellationToken: cancellationToken);

        return blobClient.Name;
    }

    public async Task<bool> DeleteFileAsync(string containerName, string blobName, CancellationToken cancellationToken = default)
    {
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        // Obtener el cliente del blob
        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        // Intentar eliminar el blob y devolver true si tuvo éxito
        return await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
    }

    public async Task<BlobFile?> DownloadBlobAsync(string containerName, string blobName,
        CancellationToken cancellationToken = default)
    {
        var container = blobServiceClient.GetBlobContainerClient(containerName);
        var decodedBlobName = HttpUtility.UrlDecode(blobName);
        var blobClient = container.GetBlobClient(decodedBlobName);

        try
        {
            var properties = await blobClient.GetPropertiesAsync(cancellationToken: cancellationToken);

            var contentLength = properties.Value.ContentLength;
            var lastModified = properties.Value.LastModified;
            var etagHash = lastModified.ToFileTime() ^ contentLength;
            var stream = await blobClient.OpenReadAsync(cancellationToken: cancellationToken);

            return new BlobFile
            {
                FileName = Path.GetFileName(decodedBlobName),
                ContentType = properties.Value.ContentType,
                ContentLength = contentLength,
                LastModified = properties.Value.LastModified,
                Etag = $"\"{Convert.ToString(etagHash, 16)}\"",
                Content = stream
            };
        }
        catch
        {
            return null;
        }
    }

    //public async Task DeleteBlobsByPrefix(string containerName, string prefix,
    //    CancellationToken cancellationToken = default)
    //{
    //    var container = blobServiceClient.GetBlobContainerClient(containerName);
    //    var blobs = container.GetBlobsAsync(prefix: prefix, cancellationToken: cancellationToken);
    //    if (blobs != null)
    //        await foreach (var blob in blobs)
    //            await container.DeleteBlobIfExistsAsync(blob.Name, cancellationToken: cancellationToken);
    //}

    //public Uri GetBlobSharedAccessSignatureUri(
    //    string containerName,
    //    string blobName,
    //    DateTimeOffset expiresOn,
    //    BlobSasPermissions permissions = BlobSasPermissions.Read)
    //{
    //    var container = blobServiceClient.GetBlobContainerClient(containerName);
    //    var decodedBlobName = HttpUtility.UrlDecode(blobName);
    //    var blobClient = container.GetBlobClient(decodedBlobName);

    //    var blobSasBuilder = new BlobSasBuilder
    //    {
    //        BlobContainerName = containerName,
    //        BlobName = blobName,
    //        Resource = "b",
    //        ExpiresOn = expiresOn
    //    };

    //    blobSasBuilder.SetPermissions(permissions);

    //    return blobClient.GenerateSasUri(blobSasBuilder);
    //}

    public async Task DeleteContainerAsync(string containerName)
    {
        if (string.IsNullOrWhiteSpace(containerName))
            return;
        var container = blobServiceClient.GetBlobContainerClient(containerName);
        await container.DeleteIfExistsAsync();
    }

    //public async Task<bool> CopyBlobAsync(
    //    string sourceContainerName,
    //    string sourceBlobName,
    //    string destinationContainerName,
    //    string destinationBlobName,
    //    CancellationToken cancellationToken = default)
    //{
    //    var sourceContainer = blobServiceClient.GetBlobContainerClient(sourceContainerName);
    //    var sourceBlob = sourceContainer.GetBlobClient(sourceBlobName);

    //    var destinationContainer = blobServiceClient.GetBlobContainerClient(destinationContainerName);
    //    var destinationBlob = destinationContainer.GetBlobClient(destinationBlobName);
    //    try
    //    {
    //        var copyFromUriOperation =
    //            await destinationBlob.StartCopyFromUriAsync(sourceBlob.Uri, cancellationToken: cancellationToken);
    //        await copyFromUriOperation.WaitForCompletionAsync(cancellationToken);
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}

    public string? CreateUriSASTokenForBlobRead(string containerName, string uniqueName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        if (!containerClient.CanGenerateSasUri)
        {
            return null;
        }

        var sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName = containerClient.Name,
            Resource = "b",
            ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(3)
        };

        sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

        var sasURI = containerClient.GenerateSasUri(sasBuilder);
        var absolute = sasURI.AbsoluteUri.Split("?");

        //return new Uri(absolute[0] + "/" + uniqueName + "?" + absolute[absolute.Length - 1]);
        return $"{absolute[0]}/{uniqueName}?{absolute[absolute.Length - 1]}";
    }
}