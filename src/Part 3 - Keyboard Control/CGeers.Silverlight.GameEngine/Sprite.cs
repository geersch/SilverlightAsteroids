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
    }
}
