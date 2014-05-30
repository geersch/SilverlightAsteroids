using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CGeers.Silverlight.GameEngine
{
    public interface ISpriteDesign
    {
        UIElement UIElement { get; }
        double Width { get; set; }
        double Height { get; set; }
        Canvas LayoutRoot { get; }
        Path RootPath { get; }
    }
}
