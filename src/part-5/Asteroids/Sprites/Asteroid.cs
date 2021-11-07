using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;
using CGeers.Silverlight.GameEngine;
using Asteroids.Sprites.Design;

namespace Asteroids.Sprites
{
    public class Asteroid : Sprite
    {
        private double _angle = 0;
        private const int AsteroidSpeed = 1;

        public Asteroid(IAsteroidDesign design, Point initialLocation)
            : base(design, initialLocation)
        {
            Random randomizer = new Random();
            this._angle = randomizer.Next(0, 360);
        }

        public override void Update(TimeSpan elapsedTime)
        {
            double radians = Math.PI * this._angle / 180.0;

            X += Math.Sin(radians) * AsteroidSpeed;
            Y -= Math.Cos(radians) * AsteroidSpeed;

            this.KeepSpriteWithinParentCanvasBounds();
        }

        public override bool HasMovedBeyondRightBound
        {
            get
            {
                return this.X >= this.ParentCanvas.Width - this.Design.Width;
            }
        }

        public override bool HasMovedBeyondBottomBound
        {
            get
            {
                return this.Y >= this.ParentCanvas.Height - this.Design.Height;
            }
        }
    }
}
