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
        private Point newStart;
        private Point newEnd;
        internal Rectang()
        { }
        public Rectang(Point startPoint, Point endPoint)
        {
            this.Start = startPoint;
            this.End = endPoint;
            Width = (int)Math.Abs(this.End.X - this.Start.X);
            Height = (int)Math.Abs(this.End.Y - this.Start.Y);
           
            newStart = Utils.GetBounding(Start, End).TopLeft;
            newEnd = Utils.GetBounding(Start, End).BottomDown;
            SolidBrush = new SolidBrush(Color.DarkRed);
        }

        internal (Point TopLeft , Point BottomDown) GetBounding()
        {
            return (newStart, newEnd);
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
            Rectangle rectangle = new Rectangle(newStart, size);
            graphics.DrawRectangle(Pen, rectangle);
        }

        public  void FillDraw(Graphics graphics)
        {
            Size size = new Size(Width, Height);
            Rectangle rectangle = new Rectangle(newStart, size);
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