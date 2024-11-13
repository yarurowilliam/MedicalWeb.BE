using Microsoft.IdentityModel.Tokens;
using SkiaSharp;

namespace MedicalWeb.BE.Infraestructure.Services
{
    public class SkiaSharpImageService : IImageService
    {
        private const SKEncodedImageFormat DEFAULT_IMAGE_FORMAT = SKEncodedImageFormat.Png;
        private readonly Dictionary<string, SKEncodedImageFormat> _skiaSharpImageFormatMapping = new(StringComparer.InvariantCultureIgnoreCase)
        {
            {".png", SKEncodedImageFormat.Png },
            {".jpg", SKEncodedImageFormat.Jpeg },
            {".jpeg", SKEncodedImageFormat.Jpeg }
        };

        public Stream Resize(Stream imageStream, string extension, int maxWidth, int maxHeight)
        {
            var dimensionScaler = new MaximumDimensionsScaler(); //todo: inject

            using (var skImage = SKBitmap.Decode(imageStream))
            {
                var maximumDimensions = new Dimensions(maxWidth, maxHeight);
                var sourceDimensions = new Dimensions(skImage.Width, skImage.Height);
                var scaledDimensions = dimensionScaler.ScaleDimensions(maximumDimensions, sourceDimensions);

                using (var scaledBitmap = skImage.Resize(new SKImageInfo(scaledDimensions.Width, scaledDimensions.Height), SKFilterQuality.Medium))
                {
                    using (var image = SKImage.FromBitmap(scaledBitmap))
                    {
                        using (var encodedImage = image.Encode(GetSkiaSharpImageFormatFromExtension(extension), 50))
                        {
                            var stream = new MemoryStream();
                            encodedImage.SaveTo(stream);
                            stream.Seek(0, SeekOrigin.Begin);
                            return stream;
                        }
                    }
                }
            }
        }

        public SKEncodedImageFormat GetSkiaSharpImageFormatFromExtension(string extension)
        {
            if (extension.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(extension));
            }

            return _skiaSharpImageFormatMapping.TryGetValue(extension, out SKEncodedImageFormat imageFormat) ? imageFormat : DEFAULT_IMAGE_FORMAT;
        }
    }
}
