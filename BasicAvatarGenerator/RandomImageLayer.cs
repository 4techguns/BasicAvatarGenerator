using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BasicAvatarGenerator
{
    public class RandomImageLayer : ILayer
    {
        private readonly int _xPos;
        private readonly int _yPos;
        private readonly int _width;
        private readonly int _height;
        private readonly Rectangle _rect;
        public string[] Images;

        public RandomImageLayer(int xPos, int yPos, int width, int height, params string[] images)
        {
            _xPos = xPos;
            _yPos = yPos;
            _width = width;
            _height = height;
            _rect = new Rectangle(_xPos, _yPos, _width, _height);
            Images = images;
        }

        public Color GetColour() => Color.White;

        public Image GetImg() => Image.Load(Images[new Random().Next(Images.Length)]);

        public Rectangle GetRect() => new Rectangle(0, 0, 0, 0); // Stub method
    }
}
