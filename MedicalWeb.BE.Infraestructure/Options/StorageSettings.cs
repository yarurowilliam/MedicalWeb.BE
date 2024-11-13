namespace MedicalWeb.BE.Infraestructure.Options;

public record StorageSettings
{
    public string ImagesContainerName { get; set; } = default!;
    public string ThumbnailContainerName { get; set; } = default!;

}
