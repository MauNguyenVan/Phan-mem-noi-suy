using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
    class FreeLine : Shape
    {
        Point[] Points { get; set; }
        internal FreeLine(Point[] points)
        {
            Points = new Point[points.Length];
            Points = points;
        }
        protected override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddLines(Points);
                return graphicsPath;
            }
        }
        public override void Draw(Graphics graphics)
        {
            //  using GraphicsPath graphicPath = GraphicsPath;
            if (IsVisible)
            {
                const int size = 6;
                if (IsSelected)
                {
                    using Pen pen = new Pen(Color.Yellow, 3)
                    {
                        DashStyle = this.DashStyle,
                    };
                    SolidBrush newSolidBrush = new SolidBrush(Color.Yellow);
                    graphics.DrawPath(pen, GraphicsPath);

                }
            }
        }
    }
}
