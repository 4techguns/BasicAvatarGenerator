using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;


namespace BasicAvatarGenerator
{

    public class Avatar
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Image<Rgba32> _base;
        private readonly ILayer[] _layers;

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="width">How long the image will be.</param>
        /// <param name="height">How tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int width, int height, params ILayer[] layers)
        {
            _width = width;
            _height = height;
            _base = new(_width, _height);
            _layers = layers;
        }

        /// <summary>
        /// This generates the image. You can also use the unified method <seealso cref="FullGenerate(string)"/>.
        /// </summary>
        public void Draw()
        {
            foreach (ILayer layer in _layers)
            {
                if (layer.GetType().Name == "RandomColourLayer")
                    _base.Mutate(
                        x => x.Fill(layer.GetColour(), layer.GetRect()));
                else if (layer.GetType().Name == "StaticColourLayer")
                    _base.Mutate(
                        x => x.Fill(layer.GetColour(), layer.GetRect())); // same thing, just different functionality
                else if (layer.GetType().Name == "RandomImageLayer")
                    _base.Mutate(
                        x => x.DrawImage(layer.GetImg(), 1.0f));
            }
        }
        public void ToFile(string name) => _base.Save(name);
        public void FullGenerate(string name)
        {
            Draw(); ToFile(name);
        }

    }
}