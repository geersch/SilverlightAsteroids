using System.Windows;
using System.Windows.Controls;

namespace CGeers.Silverlight.GameEngine
{
    public abstract class Sprite : GameElement
    {
        protected Sprite(ISpriteDesign design, Point initialLocation)
            : base()
        {
            this.Design = design;

            this.ParentCanvas.Children.Add(this.Design.UIElement);

            X = initialLocation.X;
            Y = initialLocation.Y;
        }

        public ISpriteDesign Design { get; set; }

        public double X
        {
            get
            {
                return (double) this.Design.UIElement.GetValue(Canvas.LeftProperty);
            }
            set
            {
                this.Design.UIElement.SetValue(Canvas.LeftProperty, value);
            }
        }

        public double Y
        {
            get
            {
                return (double) this.Design.UIElement.GetValue(Canvas.TopProperty);
            }
            set
            {
                this.Design.UIElement.SetValue(Canvas.TopProperty, value);
            }
        }

        #region Parent Canvas Bounds

        public virtual bool HasMovedBeyondRightBound
        {
            get
            {
                if ((this.X >= this.ParentCanvas.Width) || 
                    ((this.X + this.Design.Width) >= this.ParentCanvas.Width))
                {
                    return true;
                }
                return false;
            }
        }

        public virtual bool HasMovedBeyondLeftBound
        {
            get { return this.X <= 0; }
        }

        public bool HasMovedBeyondXAxis
        {
            get { return HasMovedBeyondLeftBound || HasMovedBeyondRightBound; }
        }

        public virtual bool HasMovedBeyondUpperBound
        {
            get { return this.Y <= 0; }
        }

        public virtual bool HasMovedBeyondBottomBound
        {
            get
            {
                if ((this.Y >= this.ParentCanvas.Height) || 
                    ((this.Y + this.Design.Height) >= this.ParentCanvas.Height))
                {
                    return true;
                }
                return false;
            }
        }

        public bool HasMovedBeyondYAxis
        {
            get { return HasMovedBeyondUpperBound || HasMovedBeyondBottomBound; }
        }

        public bool HasMovedOutOfParentCanvasBounds
        {
            get { return HasMovedBeyondXAxis || HasMovedBeyondYAxis; }
        }

        protected void KeepSpriteWithinParentCanvasBounds()
        {
            //If the sprite goes off the board in either direction then just make it flip to the other side
            if (this.HasMovedBeyondRightBound)
            {
                this.X = 1;
            }
            else if (this.HasMovedBeyondLeftBound)
            {
                this.X = this.ParentCanvas.Width - this.Design.Width;
            }
            if (this.HasMovedBeyondBottomBound)
            {
                this.Y = 1;
            }
            else if (this.HasMovedBeyondUpperBound)
            {
                this.Y = this.ParentCanvas.Height - this.Design.Height;
            }
        }

        public override void Destroy()
        {
            this.ParentCanvas.Children.Remove(this.Design.UIElement);
            base.Destroy();
        }

        #endregion

        #region Collision Detection

        public Point Location
        {
            get { return new Point(this.X, this.Y); }
        }

        public Size Size
        {
            get { return new Size(this.Design.Width, this.Design.Height); }
        }

        public Rect BoundsRect
        {
            get { return new Rect(this.Location, this.Size); }
        }

        /// <summary>
        /// Triggered by the CollisionManager when a collision with another GameElement occurs. 
        /// </summary>
        /// <param name="gameElement">The gameElement that collides with this GameElement instance</param>
        public virtual void Collision(Sprite sprite)
        { }

        #endregion
    }
}
