namespace MedicalWeb.BE.Infraestructure.Services;

public class BlobFile : IAsyncDisposable, IDisposable
{
    public required string FileName { get; set; }
    public required string ContentType { get; set; }
    public required DateTimeOffset LastModified { get; set; }
    public required string Etag { get; set; }
    public required long ContentLength { get; set; }
    public required Stream Content { get; set; }

    public void Dispose()
    {
        Content?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await Content.DisposeAsync();
    }
}