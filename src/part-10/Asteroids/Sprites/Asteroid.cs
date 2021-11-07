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

        public Asteroid(IAsteroidDesign design, Point initialLocation, double angle)
            : base(design, initialLocation)
        {
            this._angle = angle;
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

        public override void Collision(Sprite sprite)
        {
            this.Destroy();

            AsteroidSize asteroidSize = ((AsteroidDesign) this.Design).AsteroidSize;
            switch (asteroidSize)
            {
                case AsteroidSize.Large:
                    this.BreakUp(AsteroidSize.Medium);
                    break;
                case AsteroidSize.Medium:
                    this.BreakUp(AsteroidSize.Small);
                    break;
            }                     
        }

        private void BreakUp(AsteroidSize asteroidSize)
        {
            Random randomizer = new Random();
            for (int i = 0; i < 3; i++)
            {
                Point location = new Point(this.X + randomizer.Next(10, 30),
                                           this.Y + randomizer.Next(20, 50));
                double angle = randomizer.Next(0, 360);
                new Asteroid(new AsteroidDesign(asteroidSize), location, angle);
            }
        }
    }
}
