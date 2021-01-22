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
        internal Point Min { get; }
        internal Point Max { get; }
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
            this.Min = min;
            this.Max = max;
            Width = Math.Abs(this.Max.X - this.Min.X);
            Height = Math.Abs(this.Max.Y - this.Min.Y);
        }
        internal static bool IsPointInBouding(Point pointCheck, BoundingBox boundingBox)
        {
            bool isIn = false;
            if (pointCheck.X >= boundingBox.Min.X && pointCheck.Y >= boundingBox.Min.Y
               && pointCheck.X <= boundingBox.Max.X && pointCheck.Y <= boundingBox.Max.Y
                )
            {
                isIn = true;
            }
            return isIn;
        }

    }
}
