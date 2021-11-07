using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CGeers.Silverlight.GameEngine;

namespace Asteroids.Sprites.Design
{
    public partial class ExplosionDesign : UserControl, IAnimatedSpriteDesign
    {
        public ExplosionDesign()
        {
            InitializeComponent();
        }

        private bool _stop = false;
        private int _currentFrame = 0;
        private TimeSpan _lastTick = TimeSpan.Zero;
        private readonly TimeSpan _animationDelay = TimeSpan.FromSeconds(.05);

        public void Update(TimeSpan elapsedTime)
        {
            if (this._currentFrame == 7)
            {
                Visibility = Visibility.Collapsed;
                this._stop = true;
                return;
            }

            this._lastTick += elapsedTime;
            if (this._lastTick > this._animationDelay)
            {
                this._lastTick -= this._animationDelay;

                string filename = 
                    String.Format("/Asteroids;component/Media/Images/Explosion{0}.png", 
                    this._currentFrame);
                Image.Source = new BitmapImage(new Uri(filename, UriKind.Relative));

                this._currentFrame += 1;
            }
        }

        public bool IsCompleted
        {
            get { return this._stop; }
        }

        public UIElement UIElement
        {
            get { return this; }
        }

        public Canvas LayoutRoot
        {
            get { return this.ExplosionCanvas; }
        }

        public Path RootPath
        {
            get { return null; }
        }
    }
}
