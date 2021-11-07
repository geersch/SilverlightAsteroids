using CGeers.Silverlight.GameEngine;
using System.Windows;
using System.Windows.Media;

namespace Asteroids.Sprites.Design
{
    public interface ISpaceshipDesign : ISpriteDesign
    {
        RotateTransform RotateTransform { get; }
        Visibility ThrustVisibility { get; set; }
        Point GunLocation { get; }
        double Angle { get; }
    }
}
