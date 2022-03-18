using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixLabors.Fonts;
using BasicAvatarGenerator;
using SixLabors.ImageSharp;
using System.Reflection;

namespace BasicAvatarGenerator.Tests
{
    [TestClass]
    public class ImageTests
    {
        [TestCategory("Singular")]
        [TestMethod]
        public void GenerateFromImage()
        {
            RandomImageLayer layer = new(0, 0, "py_template.png");
            Avatar av = new(512, 512, layer);

            av.FullGenerate("rawImageTest.png");
        }
        [TestCategory("Stacked")]
        [TestMethod]
        public void StackImages()
        {
            RandomImageLayer layer = new(-256, 0, "py_template.png");
            RandomImageLayer layer2 = new(0, 0, "py_template.png");
            RandomImageLayer layer3 = new(256, 0, "py_template.png");
            Avatar av = new(512, 512, layer, layer2, layer3);

            av.FullGenerate("stackedImageTest.png");
        }
        [TestCategory("Singular")]
        [TestMethod]
        public void SingleColourBehindImage()
        {
            RandomColorLayer layerBehind = new(0, 0, 512, 512);
            RandomImageLayer layer = new(0, 0, "py_template.png");
            Avatar av = new(512, 512, layerBehind, layer);

            av.FullGenerate("colourBehindImageTest.png");
        }
        [TestCategory("Stacked")]
        [TestMethod]
        public void ColourBehindStackedImages()
        {
            RandomColorLayer layerBehind = new(0, 0, 512, 512);
            RandomImageLayer layer = new(-256, 0, "py_template.png");
            RandomImageLayer layer2 = new(0, 0, "py_template.png");
            RandomImageLayer layer3 = new(256, 0, "py_template.png");
            Avatar av = new(512, 512, layerBehind, layer, layer2, layer3);

            av.FullGenerate("colourBehindImagesTest.png");
        }
        [TestCategory("Stacked")]
        [TestMethod]
        public void StackedColoursBehindImage()
        {
            RandomColorLayer layerBehind = new(0, 0, 512, 512);
            RandomColorLayer layerBehind2 = new(32, 0, 512, 512);
            RandomColorLayer layerBehind3 = new(64, 0, 512, 512);
            RandomColorLayer layerBehind4 = new(72, 0, 512, 512);
            RandomImageLayer layer = new(0, 0, "py_template.png");
            Avatar av = new(512, 512, layerBehind, layerBehind2, layerBehind3, layerBehind4, layer);

            av.FullGenerate("coloursBehindImageTest.png");
        }
        [TestCategory("Stacked")]
        [TestMethod]
        public void StackedColoursBehindStackedImages()
        {
            RandomColorLayer layerBehind = new(0, 0, 512, 512);
            RandomColorLayer layerBehind2 = new(32, 0, 512, 512);
            RandomColorLayer layerBehind3 = new(64, 0, 512, 512);
            RandomColorLayer layerBehind4 = new(72, 0, 512, 512);
            RandomImageLayer layer = new(-256, 0, "py_template.png");
            RandomImageLayer layer2 = new(0, 0, "py_template.png");
            RandomImageLayer layer3 = new(256, 0, "py_template.png");
            Avatar av = new(512, 512, layerBehind, layerBehind2, layerBehind3, layerBehind4, layer, layer2, layer3);

            av.FullGenerate("coloursBehindImagesTest.png");
        }

        [TestCategory("Fonts")]
        [TestMethod]
        public void Text()
        {
            FontCollection collection = new();
            FontFamily family = collection.Add("Fonts/PermanentMarker-Regular.ttf");
            Font font = family.CreateFont(24, FontStyle.Italic);
            
            Avatar av = new(512, 512);
            DebugInfo dbg = av.GetDebugInfo();

            av.AddLayer(new TextLayer(0, 0, font, 
                $"Hello world!" +
                $"\n-- DEBUG INFO --" +
                $"\nBasicAvatarGenerator v{dbg.debugVersion}" +
                $"\nSize: {dbg.imageWidth}x{dbg.imageHeight}" +
                $"\nLayers (before rendering this text): {dbg.layers.Count}", 
                Color.White)
            );

            av.FullGenerate("TextTest.png");
        }
    }
}
