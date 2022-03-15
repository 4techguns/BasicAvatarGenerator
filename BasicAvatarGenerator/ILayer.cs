using SixLabors.ImageSharp;

namespace BasicAvatarGenerator
{
    /// <summary>
    /// A stub interface.
    /// </summary>
    public interface ILayer
    {
        Color GetColour();
        Rectangle GetRect();
        Image GetImg();
    }
}
