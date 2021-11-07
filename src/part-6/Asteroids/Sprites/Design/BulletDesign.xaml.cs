using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;
using CGeers.Silverlight.GameEngine;

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
    }
}
