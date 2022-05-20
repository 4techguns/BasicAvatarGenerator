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

        public int Width { get; init; }
        public int Height { get; init; }
        public Image<Rgba32> Base { get; init; }
        public List<ILayer> Layers { get; set; }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="width">How long the image will be.</param>
        /// <param name="height">How tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int width, int height, params ILayer[] layers)
        {
            Width = width;
            Height = height;
            Base = new(Width, Height);
            Layers = layers.ToList();
        }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="scale">How wide and tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int scale, params ILayer[] layers)
        {
            Width = scale;
            Height = scale;
            Base = new(Width, Height);
            Layers = layers.ToList();
        }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="width">How long the image will be.</param>
        /// <param name="height">How tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int width, int height, List<ILayer> layers)
        {
            Width = width;
            Height = height;
            Base = new(Width, Height);
            Layers = layers;
        }

        /// <summary>
        /// Creates a new avatar image with the specified layers and dimensions.
        /// </summary>
        /// <param name="scale">How wide and tall the image will be.</param>
        /// <param name="layers">Layers that will be put on the base image.</param>
        public Avatar(int scale, List<ILayer> layers)
        {
            Width = scale;
            Height = scale;
            Base = new(Width, Height);
            Layers = layers;
        }

        /// <summary>
        /// Adds a layer to the avatar.
        /// </summary>
        /// <param name="layer">The layer to add.</param>
        public void AddLayer(ILayer layer) => Layers.Add(layer);

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
        public void RemoveLayer(ILayer layer) => Layers.Remove(layer);

        /// <summary>
        /// Removes the last added Layer.
        /// </summary>
        public void PopLayer() => Layers.RemoveAt(Layers.Count);

        /// <summary>
        /// Clears all layers in the avatar.
        /// </summary>
        public void ClearLayers() => Layers.RemoveAll(layer => true);

        /// <summary>
        /// This generates the image. You can also use the unified method <seealso cref="FullGenerate(string)"/>.
        /// </summary>
        public void Draw()
        {
            foreach (ILayer layer in Layers)
            {
                switch (layer)
                {
                    case StaticColorLayer:
                    case RandomColorLayer:
                        Base.Mutate(
                            x => x.Fill(layer.GetColour(), layer.GetRect()));
                        break;
                    case RandomImageLayer:
                        Base.Mutate(
                            x => x.DrawImage(layer.GetImg(), layer.PositionToPoint(), 1.0f));
                        break;
                    case TextLayer:
                        Base.Mutate(
                            x => x.DrawText(new TextOptions(layer.GetFont()), layer.GetText(), layer.GetColour()));
                        break;
                    
                }
            }
        }
        public void ToFile(string name) => Base.Save(name);
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