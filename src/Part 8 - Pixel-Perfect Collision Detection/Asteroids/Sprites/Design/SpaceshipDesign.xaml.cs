using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

        public RotateTransform RotateTransform
        {
            get { return this.RotateShip; }
        }

        public Visibility ThrustVisibility
        {
            get { return ShipThrust.Visibility; }
            set { this.ShipThrust.Visibility = value; }
        }

        public Point GunLocation
        {
            get
            {
                double x = (double) this.GetValue(Canvas.LeftProperty) + 21;
                double y = (double) this.GetValue(Canvas.TopProperty) + 17;
                return new Point(x, y);
            }
        }

        public double Angle
        {
            get { return this.RotateShip.Angle; }
        }

        public Canvas LayoutRoot
        {
            get { return this.Ship; }
        }

        public Path RootPath
        {
            get { return this.SpaceShipPath; }
        }
    }
}
