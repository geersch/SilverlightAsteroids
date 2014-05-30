using System.Windows;

namespace CGeers.Silverlight.GameEngine
{
    public interface ISpriteDesign
    {
        UIElement UIElement { get; }
        double Width { get; set; }
        double Height { get; set; }
    }
}
