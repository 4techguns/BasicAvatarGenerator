using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace BasicAvatarGenerator
{
    /// <summary>
    /// A class that is similar to <see cref="RandomColorLayer"/>, but lets you specify the colour.
    /// Be cautious that this does require ImageSharp to be present in your project to get the Color class.
    /// </summary>
    public class StaticColorLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        private readonly int _width;
        private readonly int _height;
        private readonly Rectangle _rect;
        private readonly Color _colour;

        public StaticColorLayer(int xPos, int yPos, int width, int height, Color colour)
        {
            _xPos = xPos;
            _yPos = yPos;
            _width = width;
            _height = height;
            _colour = colour;
            _rect = new Rectangle(_xPos, _yPos, _width, _height);
        }

        public Color GetColour() => _colour;

        public Rectangle GetRect() => _rect;
        public Image GetImg() => throw new NotImplementedException();
        public Font GetFont() => throw new NotImplementedException();
        public Point PositionToPoint() => new(_xPos, _yPos);
        public string GetText() => string.Empty;
    }
}
