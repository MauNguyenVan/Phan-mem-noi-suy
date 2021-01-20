using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
    internal abstract class Shape
    {
        public string Name { get; protected set; } = "Unknow";
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }
        public Pen Pen { get; set; }
        public SolidBrush SolidBrush { get; set; }
        public int LineWidth { get; set; }
        public DashStyle DashStyle { get; set; } = DashStyle.Solid;
        public bool IsSelected { get; set; }
        public bool IsVisible { get; set; }

        protected abstract GraphicsPath GraphicsPath { get; }

        public abstract bool IsHit(Point point);

        public abstract void Draw(Graphics graphics);

        public abstract void Move(Point distance);

        public abstract object Clone();

        public override string ToString()
        {
            return $"{Name} [({Start.X},{Start.Y});({End.X},{End.Y})]";
        }
    }
}