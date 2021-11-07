using System;
using System.Windows;
using Asteroids.Sprites.Design;
using CGeers.Silverlight.GameEngine;

namespace Asteroids.Sprites
{
    public class Spaceship : Sprite
    {
        public Spaceship(ISpaceshipDesign design, Point initialLocation)
            : base(design, initialLocation)
        { }

        public override void Update(TimeSpan elapsedTime)
        { }
    }
}
