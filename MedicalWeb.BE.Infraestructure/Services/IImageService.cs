namespace MedicalWeb.BE.Infraestructure.Services
{
    public interface IImageService
    {
        public Stream Resize(Stream imageStream, string extension, int maxWidth, int maxHeight);
    }
}
