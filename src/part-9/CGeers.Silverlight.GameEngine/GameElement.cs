using System;
using System.Windows.Controls;

namespace CGeers.Silverlight.GameEngine
{
    public abstract class GameElement : IDisposable
    {
        protected GameElement() : base()
        {
            GameSurface gameSurface = GameSurface.GetInstance();

            gameSurface.AddGameElement(this);
            this.ParentCanvas = gameSurface.Canvas;
        }

        public abstract void Update(TimeSpan elapsedTime);

        public Canvas ParentCanvas { get; private set; }

        public event EventHandler Destroyed;

        public virtual void Destroy()
        {
            GameSurface.GetInstance().RemoveGameElement(this);
            if (this.Destroyed != null)
            {
                this.Destroyed(this, new EventArgs());
            }
        }

        #region IDisposable Members

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Clean up any managed resources here.
                    // ...
                }

                // Clean up any unmanaged resources here.
                // ...

                // Unregister the game element with the surface 
                GameSurface.GetInstance().RemoveGameElement(this);

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GameElement()
        {
            Dispose(false);
        }

        #endregion}
    }
}
