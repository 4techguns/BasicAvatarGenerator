using SixLabors.ImageSharp;
using SixLabors.Fonts;

namespace BasicAvatarGenerator
{
    public class TextLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        private readonly Font _font;
        private readonly string _text;
        private readonly Color _colour;
        public TextLayer(int xPos, int yPos, Font font, string text, Color colour)
        {
            _xPos = xPos;
            _yPos = yPos;
            _font = font;
            _text = text;
            _colour = colour;
        }

        public Color GetColour() => _colour;

        #region Stubs, please ignore
        public Rectangle GetRect() => throw new NotImplementedException();
        public Image GetImg() => throw new NotImplementedException();
        #endregion

        public Point PositionToPoint() => new(_xPos, _yPos);
        public Font GetFont() => _font;
        public string GetText() => _text;
    }
}
