using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BasicAvatarGenerator
{
    /// <summary>
    /// A type of <see cref="ILayer"/> that picks from a list of images, provided using path strings.
    /// <example><code>RandomImageLayer l = new(0, 0, 128, 128, "image0.png", "image1.png");</code></example>
    /// </summary>
    public class RandomImageLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        public string[] Images;

        public RandomImageLayer(int xPos, int yPos, params string[] images)
        {
            _xPos = xPos;
            _yPos = yPos;
            Images = images;
        }

        public Color GetColour() => Color.White;

        public Image GetImg() => Image.Load(Images[new Random().Next(Images.Length)]);

        public Rectangle GetRect() => new Rectangle(0, 0, 0, 0); // Stub method
        public Point PositionToPoint() => new Point(_xPos, _yPos);
    }
}
