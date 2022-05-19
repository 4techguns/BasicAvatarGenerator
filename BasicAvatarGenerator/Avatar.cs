using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.Fonts;
using System.Reflection;

namespace BasicAvatarGenerator
{
    public class Avatar : IDisposable
    {
        private bool disposed = false;
        private readonly int _width;
        private readonly int _height;
        private readonly Image<Rgba32> _base;
        private readonly List<ILayer> _layers;

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
            _layers = layers.ToList();
        }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="scale">How wide and tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int scale, params ILayer[] layers)
        {
            _width = scale;
            _height = scale;
            _base = new(_width, _height);
            _layers = layers.ToList();
        }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="width">How long the image will be.</param>
        /// <param name="height">How tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int width, int height, List<ILayer> layers)
        {
            _width = width;
            _height = height;
            _base = new(_width, _height);
            _layers = layers;
        }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="scale">How wide and tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int scale, List<ILayer> layers)
        {
            _width = scale;
            _height = scale;
            _base = new(_width, _height);
            _layers = layers;
        }

        /// <summary>
        /// Gets all the layers in the current Avatar instance.
        /// </summary>
        /// <returns>The list of layers</returns>
        public List<ILayer> GetLayers() => _layers;

        /// <summary>
        /// Adds a layer to the avatar.
        /// </summary>
        /// <param name="layer">The layer to add.</param>
        public void AddLayer(ILayer layer) => _layers.Add(layer);

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                disposed = true;
            }
        }

        /// <summary>
        /// Removes the specified layer. Can be useful for freeing memory, but it's more convenient to use <see cref="ClearLayers"/> instead.
        /// </summary>
        /// <param name="layer"></param>
        public void RemoveLayer(ILayer layer) => _layers.Remove(layer);

        /// <summary>
        /// Removes the last added Layer.
        /// </summary>
        public void PopLayer() => _layers.RemoveAt(_layers.Count);

        /// <summary>
        /// Clears all layers in the avatar. Extremely useful for freeing memory when you don't need the avatar anymore.
        /// </summary>
        public void ClearLayers() => _layers.RemoveAll(layer => true);

        public DebugInfo GetDebugInfo() => new DebugInfo
        {
            debugVersion = typeof(Avatar).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? "Unknown",
            imageHeight = _height,
            imageWidth = _width,
            layers = _layers
        };

        /// <summary>
        /// This generates the image. You can also use the unified method <seealso cref="FullGenerate(string)"/>.
        /// </summary>
        public void Draw()
        {
            foreach (ILayer layer in _layers)
            {
                switch (layer)
                {
                    case StaticColorLayer:
                    case RandomColorLayer:
                        _base.Mutate(
                            x => x.Fill(layer.GetColour(), layer.GetRect()));
                        break;
                    case RandomImageLayer:
                        _base.Mutate(
                            x => x.DrawImage(layer.GetImg(), layer.PositionToPoint(), 1.0f));
                        break;
                    case TextLayer:
                        _base.Mutate(
                            x => x.DrawText(new TextOptions(layer.GetFont()), layer.GetText(), layer.GetColour()));
                        break;
                    
                }
            }
        }
        public void ToFile(string name) => _base.Save(name);
        public void FullGenerate(string name)
        {
            Draw(); ToFile(name);
        }

        ~Avatar()
        {
            Dispose(disposing: false);
        }
    }
}