using System;
using System.Windows;
using Asteroids.Sprites.Design;
using CGeers.Silverlight.GameEngine;

namespace Asteroids.Sprites
{
    public class Bullet : Sprite
    {
        private readonly double _angle = 0;
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

            Point locationOfExplosion = new Point(
                this.X - sprite.Design.Width / 2, 
                this.Y - this.Design.Height / 2);
            new Explosion(new ExplosionDesign(), locationOfExplosion);
        }
    }
}
