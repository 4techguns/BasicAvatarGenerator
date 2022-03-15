using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAvatarGenerator
{
    public class StaticColourLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        private readonly int _width;
        private readonly int _height;
        private readonly Rectangle _rect;
        private readonly Color _colour;

        public StaticColourLayer(int xPos, int yPos, int width, int height, Color colour)
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

        public Image GetImg() => null;
    }
}
