using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
    internal class Rectang : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
       public BoundingBox BoundingBox { get; }
        internal Rectang()
        { }
        public Rectang(Point startPoint, Point endPoint)
        {
            this.Start = startPoint;
            this.End = endPoint;
            BoundingBox = new BoundingBox(new Point[] { Start, End });
            Width = BoundingBox.Width;
            Height = BoundingBox.Height;
            SolidBrush = new SolidBrush(Color.Green);
        }

      
        protected override GraphicsPath GraphicsPath => throw new NotImplementedException();

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        private int GetMinLength()
        {
            return Width < Height ? Width : Height;
        }
        public override void Draw(Graphics graphics)
        {
            Size size = new Size(Width, Height);
            Rectangle rectangle = new Rectangle(BoundingBox.Min, size);
            graphics.DrawRectangle(Pen, rectangle);
        }

        public  void FillDraw(Graphics graphics)
        {
            Size size = new Size(Width, Height);
            Rectangle rectangle = new Rectangle(BoundingBox.Min, size);
            graphics.FillRectangle(SolidBrush, rectangle);
        }

        public void DrawFromCenter(Graphics graphics, Point centerPoint, int width, int height)
        {
            int startX = (int)(centerPoint.X - 0.5 * width);
            int startY = (int)(centerPoint.Y - 0.5 * height);
            int endX = startX + width;
            int endY = startY + height;
            Rectang square = new Rectang(Start = new Point(startX, startY), End = new Point(endX, endY));
            square.FillDraw(graphics);
           
        }
        public override bool IsHit(Point point)
        {
            throw new NotImplementedException();
        }

        public override void Move(Point distance)
        {
            throw new NotImplementedException();
        }
    }
}