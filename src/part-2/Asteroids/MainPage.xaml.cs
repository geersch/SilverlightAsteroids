using System;
using System.Windows;
using System.Windows.Controls;
using Asteroids.Sprites;
using Asteroids.Sprites.Design;
using CGeers.Silverlight.GameEngine;

namespace Asteroids
{
    public partial class MainPage : UserControl
    {
        private GameSurface _gameSurface = GameSurface.GetInstance();
        private int _fps;
        private DateTime _lastFpsReport;

        private Spaceship _spaceShip;

        private void CreateSpaceShip()
        {
            Point centerPoint = new Point(LayoutRoot.ActualWidth / 2, LayoutRoot.ActualHeight / 2);
            this._spaceShip = new Spaceship(new SpaceshipDesign(), centerPoint);
        }

        public MainPage()
        {
            InitializeComponent();

            this._gameSurface.Canvas = this.LayoutRoot;
            this._gameSurface.RenderFrame += RenderFrame;

            CreateSpaceShip();

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
