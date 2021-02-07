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
        public int Width { get; }
        public int Height { get; }
        public int Area { get; }
        public int Primeter { get; }
        public BoundingBox BoundingBox { get; }

        internal Rectang()
        {
        }

        public Rectang(Point startPoint, Point endPoint)
        {
            this.Start = startPoint;
            this.End = endPoint;
            BoundingBox = new BoundingBox(new Point[] { Start, End });
            Width = BoundingBox.Width;
            Height = BoundingBox.Height;
            SolidBrush = new SolidBrush(Color.DarkRed);
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

        private int GetPrimeter()
        {
            return 2 * (Width + Height);
        }

        private int GetArea()
        {
            return Width * Height;
        }

        private void DrawBorder(Graphics graphics)
        {
            const int size = Shape.SizePointHighlight;
            // Draw(graphics);
            DrawFromCenter(graphics, BoundingBox.TopLeft, size, size);
            DrawFromCenter(graphics, BoundingBox.BottomRight, size, size);
            DrawFromCenter(graphics, BoundingBox.BottomLeft, size, size);
            DrawFromCenter(graphics, BoundingBox.TopRight, size, size);
        }

        public override void Draw(Graphics graphics)
        {
            Rectangle rectangle = this.BoundingBox.ToRectangle();
            graphics.DrawRectangle(Pen, rectangle);
            if (IsSelected)
            {
                DrawBorder(graphics);
            }
        }

        public void FillDraw(Graphics graphics)
        {
            Rectangle rectangle = this.BoundingBox.ToRectangle();
            graphics.FillRectangle(SolidBrush, rectangle);
            //DrawBorder(graphics);
        }

        public static void DrawFromCenter(Graphics graphics, Point centerPoint, int width, int height)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Green);
            int startX = (int)(centerPoint.X - 0.5 * width);
            int startY = (int)(centerPoint.Y - 0.5 * height);
            int endX = startX + width;
            int endY = startY + height;
            Rectangle rectangle = new Rectangle(new Point(startX, startY), new(width, height));
            graphics.FillRectangle(solidBrush, rectangle);
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