using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
    internal class Square : Shape
    {
        public Square()
        {
            SolidBrush = new SolidBrush(Color.DarkRed);
        }

        protected override GraphicsPath GraphicsPath => throw new NotImplementedException();

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        private int GetMinLength()
        {
            int lengthX = (int)Math.Abs(this.End.X - this.Start.X);
            int lengthY = (int)Math.Abs(this.End.Y - this.Start.Y);
            return lengthX < lengthY ? lengthX : lengthY;
        }

        public override void Draw(Graphics graphics)
        {
            int minLength = GetMinLength();
            Size size = new Size(minLength, minLength);
            Rectangle rectangle = new Rectangle(this.Start, size);
            graphics.FillRectangle(SolidBrush, rectangle);
        }

        public Square DrawFromCenter(Graphics graphics, Point centerPoint, int width)
        {
            Point startP = new Point(centerPoint.X - (int)(0.5 * width), centerPoint.Y - (int)(0.5 * width));
            Size size = new Size(width, width);
            Rectangle rectangle = new Rectangle(startP, size);
            // graphics.FillRectangle(solidBrush, rectangle);
            int startX = (int)(centerPoint.X - 0.5 * width);
            int startY = (int)(centerPoint.Y - 0.5 * width);
            int endX = startX + width;
            int endY = startY + width;

            Square square = new Square()
            {
                Start = new Point(startX, startY),
                End = new Point(endX, endY),
            };
            square.Draw(graphics);
            return square;
        }

        //public override void Draw(Graphics graphics)
        //{
        //    static void DrawSquare(Graphics graphics, SolidBrush solidBrush, Point point, int width)
        //    {
        //        Point startP = new Point(point.X - (int)(0.5 * width), point.Y - (int)(0.5 * width));
        //        //   Point endP = new Point(point.X + radius, point.Y + radius);
        //        Size size = new Size(width, width);
        //        Rectangle rectangle = new Rectangle(startP, size);
        //        graphics.FillRectangle(solidBrush, rectangle);
        //    }
        //}

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