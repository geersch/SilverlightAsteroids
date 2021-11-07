using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Asteroids.Sprites;
using Asteroids.Sprites.Design;
using CGeers.Silverlight.GameEngine;
using CGeers.Silverlight.GameEngine.Controllers;

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
            this._spaceShip.Destroyed += SpaceShipDestroyed;
        }

        void SpaceShipDestroyed(object sender, EventArgs e)
        {
            this._spaceShip = null;
        }

        private void CreateAsteroids()
        {
            Random randomizer = new Random();
            for (int i = 0; i < 3; i++)
            {
                double x = (double) randomizer.Next((int)this.Width);
                double y = (double) randomizer.Next((int)this.Height);
                Point randomLocation = new Point(x, y);
                new Asteroid(new AsteroidDesign(), randomLocation);
            }
        }

        public MainPage()
        {
            InitializeComponent();

            this._gameSurface.Canvas = this.LayoutRoot;
            this._gameSurface.RenderFrame += RenderFrame;

            CreateSpaceShip();
            CreateAsteroids();

            CollisionManager.Register<Asteroid, Bullet>();
            CollisionManager.Register<Spaceship, Asteroid>();

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

            // What should the space ship do?
            if (this._spaceShip != null)
            {
                if (KeyboardState.GetKeyState(Key.Up) == true)
                {
                    this._spaceShip.Thrust();
                    this._spaceShip.TurnOnEngine();
                }
                else
                {
                    this._spaceShip.Drift();
                    this._spaceShip.TurnOffEngine();
                }
                if (KeyboardState.GetKeyState(Key.Left) == true)
                {
                    this._spaceShip.TurnLeft(e.ElapsedTime);
                }
                if (KeyboardState.GetKeyState(Key.Right) == true)
                {
                    this._spaceShip.TurnRight(e.ElapsedTime);
                }
                if (KeyboardState.GetKeyState(Key.Space) == true)
                {
                    this._spaceShip.Gun.Fire();
                }
            }

            CollisionManager.GetInstance().DetectCollisions();
        }
    }
}
