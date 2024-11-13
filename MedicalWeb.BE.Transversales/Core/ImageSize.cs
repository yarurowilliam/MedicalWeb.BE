namespace MedicalWeb.BE.Transversales.Core
{
    public record ImageSize
    {
        public static ImageSize Thumbnail = new ImageSize(nameof(Thumbnail).ToUpper(), 300, 300);
        public static ImageSize Large = new ImageSize(nameof(Thumbnail).ToUpper(), 1200, 1000);

        public string Code { get; init; }
        public int MaxHeight { get; init; }
        public int MaxWidth { get; init; }

        public ImageSize(string code, int maxHeight, int maxWidth)
        {
            Code = code;
            MaxHeight = maxHeight;
            MaxWidth = maxWidth;
        }

        public static IEnumerable<ImageSize> GetAll() => new[] {
                Thumbnail,
                Large
        };

        public static ImageSize GetByCodeOrThrow(string code) => GetAll().First(x => x.Code == code);

    }
}
