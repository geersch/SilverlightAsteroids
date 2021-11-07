using System.Windows;
using System.Windows.Controls;

namespace Asteroids.Sprites.Design
{
    public partial class SpaceshipDesign : UserControl, ISpaceshipDesign
    {
        public SpaceshipDesign()
        {
            InitializeComponent();
        }

        public UIElement UIElement
        {
            get { return this; }
        }
    }
}
