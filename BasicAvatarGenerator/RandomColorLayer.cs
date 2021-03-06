using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace BasicAvatarGenerator
{
    /// <summary>
    /// A type of <see cref="ILayer"/> that generates a random colour.
    /// </summary>
    public class RandomColorLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        private readonly int _width;
        private readonly int _height;
        private readonly Rectangle _rect;

        public RandomColorLayer(int xPos, int yPos, int width, int height)
        {
            _xPos = xPos;
            _yPos = yPos;
            _width = width;
            _height = height;
            _rect = new Rectangle(_xPos, _yPos, _width, _height);
        }

        public Color GetColour() => Color.FromRgb(
            (byte)new Random().Next(255),
            (byte)new Random().Next(255),
            (byte)new Random().Next(255));

        public Rectangle GetRect() => _rect;

        public Image GetImg() => throw new NotImplementedException();
        public Font GetFont() => throw new NotImplementedException();
        public Point PositionToPoint() => new(_xPos, _yPos);
        public string GetText() => string.Empty;
    }
}
