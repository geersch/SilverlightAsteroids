using System;
using System.Windows;
using CGeers.Silverlight.GameEngine;
using Asteroids.Sprites.Design;

namespace Asteroids.Sprites
{
    public class Bullet : Sprite
    {
        private double _angle = 0;
        private const int BulletSpeed = 5;

        public Bullet(ISpriteDesign design, Point initialLocation, double angle)
            : base(design, initialLocation)
        {
            this._angle = angle;
        }

        public override void Update(TimeSpan elapsedTime)
        {
            double radians = Math.PI * this._angle / 180.0;

            X += Math.Sin(radians) * BulletSpeed;
            Y -= Math.Cos(radians) * BulletSpeed;

            if (this.HasMovedOutOfParentCanvasBounds)
            {
                this.Destroy();
            }
        }

        public override void Collision(Sprite sprite)
        {
            this.Destroy();
        }
    }
}
