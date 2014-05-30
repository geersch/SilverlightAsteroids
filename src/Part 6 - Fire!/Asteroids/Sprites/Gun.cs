using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;
using Asteroids.Sprites.Design;

namespace Asteroids.Sprites
{
    public class Gun
    {
        private ISpaceshipDesign _spaceshipDesign;
        private DateTime _lastTimeFired = DateTime.Now;

        public Gun(ISpaceshipDesign spaceshipDesign)
        {
            this._spaceshipDesign = spaceshipDesign;
        }

        public bool IsReloading
        {
            get
            {
                TimeSpan pause = new TimeSpan(0, 0, 0, 0, 300);
                bool reloading = this._lastTimeFired > DateTime.Now.Subtract(pause);
                return reloading;
            }
        }

        public void Fire()
        {
            if (IsReloading)
            {
                return;
            }

            Point gunLocation = _spaceshipDesign.GunLocation;
            double angle = _spaceshipDesign.Angle;

            Bullet bullet = new Bullet(new BulletDesign(), gunLocation, angle);

            this._lastTimeFired = DateTime.Now;
        }
    }
}
