namespace MedicalWeb.BE.Infraestructure.Services
{
    public class MaximumDimensionsScaler
    {
        public Dimensions ScaleDimensions(Dimensions maximum, Dimensions source)
        {
            if (maximum is null) throw new ArgumentNullException(nameof(maximum));
            if (source is null) throw new ArgumentNullException(nameof(source));

            var widthRatio = (double)maximum.Width / source.Width;
            var heightRatio = (double)maximum.Height / source.Height;

            // Use the most restrictive ratio (the one that reduces the image the most)
            var scaleFactor = Math.Min(widthRatio, heightRatio);

            // Calculate the new dimensions while maintaining the aspect ratio
            var newWidth = (int)(source.Width * scaleFactor);
            var newHeight = (int)(source.Height * scaleFactor);

            return new Dimensions(newWidth, newHeight);
        }
    }
}
