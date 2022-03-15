using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicAvatarGenerator;
using SixLabors.ImageSharp;

namespace BasicAvatarGenerator.Tests
{
    [TestClass]
    public class ColourTests
    {
        [TestMethod]
        [DataRow(128, DisplayName = "128x128")]
        [DataRow(256, DisplayName = "256x256")]
        [DataRow(512, DisplayName = "512x512")]
        [DataRow(1024, DisplayName = "1024x1024")]
        public void GenerateColouredImage(int size)
        {
            RandomColourLayer l0 = new(0, 0, size / 2, size / 2);
            Avatar av = new(size, size, l0);

            av.Draw();
            av.ToFile($"TestFile{size}.png");
        }

        [TestMethod]
        [DataRow(128, DisplayName = "128x128")]
        [DataRow(256, DisplayName = "256x256")]
        [DataRow(512, DisplayName = "512x512")]
        [DataRow(1024, DisplayName = "1024x1024")]
        public void GenerateSolidColouredImage(int size)
        {
            StaticColourLayer l0 = new(0, 0, size, size, Color.Cyan);
            Avatar av = new(size, size, l0);

            av.Draw();
            av.ToFile($"TestSolidCFile{size}.png");
        }

        [TestMethod]
        [DataRow(128, DisplayName = "128x128")]
        [DataRow(256, DisplayName = "256x256")]
        [DataRow(512, DisplayName = "512x512")]
        [DataRow(1024, DisplayName = "1024x1024")]
        public void GenerateMultiColouredImage(int size)
        {
            RandomColourLayer l0 = new(0, 0, size / 2, size / 2);
            RandomColourLayer l1 = new(25, 0, size / 2, size / 2);
            RandomColourLayer l2 = new(50, 0, size / 2, size / 2);
            RandomColourLayer l3 = new(75, 0, size / 2, size / 2);
            Avatar av = new(size, size, l0, l1, l2, l3);

            av.Draw();
            av.ToFile($"TestMultiFile{size}.png");
        }
    }
}