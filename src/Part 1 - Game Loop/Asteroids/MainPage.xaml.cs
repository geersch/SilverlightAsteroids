using System;
using System.Windows.Controls;
using CGeers.Silverlight.GameEngine;

namespace Asteroids
{
    public partial class MainPage : UserControl
    {
        private GameSurface _gameSurface = GameSurface.GetInstance();
        private int _fps;
        private DateTime _lastFpsReport;

        public MainPage()
        {
            InitializeComponent();

            this._gameSurface.RenderFrame += RenderFrame;
            this._gameSurface.StartGame();
        }

        private void RenderFrame(object sender, RenderFrameEventArgs e)
        {
            // Calculate the frame rate
            this._fps++;
            if ((DateTime.Now - this._lastFpsReport).Seconds >= 1)
            {
                FrameRate.Text = String.Format("{0} FPS", this._fps);
                this._fps = 0;
                this._lastFpsReport = DateTime.Now;                
            }
        }
    }
}
