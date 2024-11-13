namespace MedicalWeb.BE.Infraestructure.Services
{
    public record Dimensions
    {
        public int Width { get; init; }
        public int Height { get; init; }

        public Dimensions(int width, int height)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }
    }
}
