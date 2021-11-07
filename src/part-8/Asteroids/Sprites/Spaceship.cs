using System;
using System.Windows;
using Asteroids.Sprites.Design;
using CGeers.Silverlight.GameEngine;

namespace Asteroids.Sprites
{
    public class Spaceship : Sprite
    {
        private double _speed = 0;
        private double _angle = 0;
        private DateTime _lastThrust;
        private const double InitialThrustSpeed = 3;
        private const double DecelerationRate = .015;

        public Spaceship(ISpaceshipDesign design, Point initialLocation)
            : base(design, initialLocation)
        {
            this._gun = new Gun(design);        
        }

        private Gun _gun;
        public Gun Gun
        {
            get { return this._gun; }
        }      

        public void TurnLeft(TimeSpan elapsedTime)
        {
            ((ISpaceshipDesign) this.Design).RotateTransform.Angle -= 
                250 * elapsedTime.TotalSeconds;
        }

        public void TurnRight(TimeSpan elapsedTime)
        {
            ((ISpaceshipDesign) this.Design).RotateTransform.Angle +=
                250 * elapsedTime.TotalSeconds;
        }

        public void TurnOnEngine()
        {
            ((ISpaceshipDesign) this.Design).ThrustVisibility = Visibility.Visible;
        }

        public void TurnOffEngine()
        {
            ((ISpaceshipDesign) this.Design).ThrustVisibility = Visibility.Collapsed;
        }

        private void Propel()
        {
            // Convert degrees to radians. Multiply by PI and divide by 180.
            // Result : A number or expression representing the angle in radians.
            double radians = Math.PI * this._angle / 180.0;

            // Calculates the sine of x. This will be a value from -1.0 to 1.0. 
            X += Math.Sin(radians) * this._speed;

            // Calculates the cosine of x. This will be a value from -1.0 to 1.0. 
            Y -= Math.Cos(radians) * this._speed;
        }

        public void Thrust()
        {
            // At which angle do we need to propel the ship?
            // The angle is expressed in degrees.
            this._angle = ((ISpaceshipDesign) this.Design).RotateTransform.Angle;

            // Boost the speed
            this._speed = InitialThrustSpeed;

            // Remember when the last thrust occurred
            this._lastThrust = DateTime.Now;

            // Propel the ship
            Propel();
        }

        public void Drift()
        {
            // Have we run out of steam?
            if (this._speed <= 0)
            {
                return;
            }

            // Reduce the speed
            TimeSpan span = DateTime.Now - this._lastThrust;
            this._speed -= (DecelerationRate * (span.Milliseconds * .002));

            // Propel the ship
            Propel();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            this.KeepSpriteWithinParentCanvasBounds();
        }

        public override void Collision(Sprite sprite)
        {
            this.Destroy();
        }
    }
}
