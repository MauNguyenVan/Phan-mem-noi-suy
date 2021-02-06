using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
  internal readonly struct BoundingBox
    {
        internal Point TopLeft { get; }
        internal Point BottomRight { get; }
        internal Point Center { get; }
        internal Point TopRight { get; }
        internal Point BottomLeft { get; }
        internal int Width { get; }
        internal int Height { get; }
        internal  BoundingBox(Point[] arrayOfPoint )
        {
            int minx = arrayOfPoint.Min(x => x.X);
            int miny = arrayOfPoint.Min(x => x.Y);
            int maxx = arrayOfPoint.Max(x => x.X);
            int maxy = arrayOfPoint.Max(x => x.Y);
          
            Point min = new Point(minx,miny);
            Point max = new Point(maxx, maxy);
            this.TopLeft = min;
            this.BottomRight = max;
            Width = Math.Abs(this.BottomRight.X - this.TopLeft.X);
            Height = Math.Abs(this.BottomRight.Y - this.TopLeft.Y);
            this.Center = this.TopLeft + new Size((int)(0.5 * this.Width), (int)(0.5 * this.Height));
            this.TopRight = new(maxx, miny);
            this.BottomLeft = new(minx, maxy);
        }
        internal  Rectangle ToRectangle()
        {
            return new Rectangle(TopLeft, new Size(Width,Height));
        }
        internal static bool IsPointInBouding(Point pointCheck, BoundingBox boundingBox)
        {
            bool isIn = false;
            if (pointCheck.X >= boundingBox.TopLeft.X && pointCheck.Y >= boundingBox.TopLeft.Y
               && pointCheck.X <= boundingBox.BottomRight.X && pointCheck.Y <= boundingBox.BottomRight.Y)
            {
                isIn = true;
            }
            return isIn;
        }

    }
}
