﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Asteroids.Sprites.Design
{
    public partial class AsteroidDesign : UserControl, IAsteroidDesign
    {
        private readonly AsteroidSize _asteroidSize;

        public AsteroidDesign(AsteroidSize asteroidSize)
        {
            InitializeComponent();

            this._asteroidSize = asteroidSize;
            this.SetSize();

            // Texture
            ImageBrush brush = new ImageBrush();
            Uri uri = new Uri("/Media/Textures/Rock.jpg", UriKind.Relative);
            brush.ImageSource = new BitmapImage(uri);
            this.AsteroidPath.Fill = brush;

            // Rotation
            Random randomizer = new Random();
            this.EndRotationInSeconds.KeyTime = new TimeSpan(0, 0, randomizer.Next(3, 8));
            this.Rotate.Begin();
        }

        private void SetSize()
        {
            int actualSize = (int) this._asteroidSize;
            this.Width = actualSize;
            this.Height = actualSize;
            this.AsteroidPath.Width = actualSize;
            this.AsteroidPath.Height = actualSize;
        }

        public AsteroidSize AsteroidSize
        {
            get { return this._asteroidSize; }
        }

        public UIElement UIElement
        {
            get { return this; }
        }

        public Canvas LayoutRoot
        {
            get { return this.AsteroidCanvas; }
        }

        public Path RootPath
        {
            get { return this.AsteroidPath; }
        }
    }
}
