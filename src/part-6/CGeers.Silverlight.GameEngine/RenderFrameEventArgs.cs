using System;

namespace CGeers.Silverlight.GameEngine
{
    public class RenderFrameEventArgs : EventArgs
    {
        public TimeSpan ElapsedTime { get; set; }
    }
}
