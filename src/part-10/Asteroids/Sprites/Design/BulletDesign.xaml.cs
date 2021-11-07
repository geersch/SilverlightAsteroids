using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Asteroids.Sprites.Design
{
    public partial class BulletDesign : UserControl, IBulletDesign
    {
        public BulletDesign()
        {
            InitializeComponent();
        }

        public UIElement UIElement
        {
            get { return this; }
        }

        public Canvas LayoutRoot
        {
            get { return this.BulletCanvas; }
        }

        public Path RootPath
        {
            get { return this.BulletPath; }
        }
    }
}
