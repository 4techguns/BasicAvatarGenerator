using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BasicAvatarGenerator
{
    /// <summary>
    /// A type of <see cref="ILayer"/> that displays an image, provided using a path string.
    /// <example><code>SingleImageLayer l = new(0, 0, 128, 128, "image0.png");</code></example>
    /// </summary>
    public class SingleImageLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        public string imagePath;

        public SingleImageLayer(int xPos, int yPos, string imagepath)
        {
            _xPos = xPos;
            _yPos = yPos;
            imagePath = imagepath;
        }

        public Color GetColour() => Color.White;

        public Font GetFont() => throw new NotImplementedException();

        public Image GetImg() => Image.Load(imagePath);

        public Rectangle GetRect() => throw new NotImplementedException();
        public Point PositionToPoint() => new(_xPos, _yPos);
        public string GetText() => string.Empty;
    }
}
