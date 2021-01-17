using System;
using System.Collections.Generic;
using System.Text;

namespace Paint.DataClass
{
  internal  class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public static int Count { get; private set; } = default;
        internal Line(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            Count++;
        }
        ~Line()
        {
            Count--;
        }
    }
}
