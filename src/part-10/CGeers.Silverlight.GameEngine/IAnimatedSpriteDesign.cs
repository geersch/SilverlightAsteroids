using System;

namespace CGeers.Silverlight.GameEngine
{
    public interface IAnimatedSpriteDesign : ISpriteDesign
    {
        void Update(TimeSpan elapsedTime);
        bool IsCompleted { get; }
    }
}
