using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace BasicAvatarGenerator
{
    /// <summary>
    /// An interface that many layer classes build off of.
    /// </summary>
    public interface ILayer
    {
        Color GetColour();
        Rectangle GetRect();
        Image GetImg();
        Point PositionToPoint();
        Font GetFont();
        string GetText();
    }
}
