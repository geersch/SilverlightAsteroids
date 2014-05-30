using System;
using System.Windows;
using CGeers.Silverlight.GameEngine;

namespace Asteroids.Sprites
{
    public class Explosion : Sprite
    {
        public Explosion(IAnimatedSpriteDesign design, Point initialLocation)
            : base(design, initialLocation)
        { }

        public override void Update(TimeSpan elapsedTime)
        {
            IAnimatedSpriteDesign design = (IAnimatedSpriteDesign) this.Design;
            design.Update(elapsedTime);

            if (design.IsCompleted)
            {
                this.Destroy();
            }
        }
    }
}
