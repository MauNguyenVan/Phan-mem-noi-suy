using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Paint.DataClass
{
    internal class Line : Shape
    {
        public Line()
        {
            this.Name = PaintTypeEnumeration.Line.ToString();
        }

        public Line(Point start, Point end, Color color, int lineWidth)
        {
            this.Name = PaintTypeEnumeration.Line.ToString();
            this.Start = start;
            this.End = end;
            this.Color = color;
            this.LineWidth = lineWidth;
        }

        protected override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddLine(this.Start, this.End);
                return graphicsPath;
            }
        }

        public override object Clone()
        {
            return new Line()
            {
                Name = Name,
                Start = Start,
                End = End,
                LineWidth = LineWidth,
                Color = Color,
                IsSelected = IsSelected,
            };
        }

        public override void Draw(Graphics graphics)
        {
            using GraphicsPath graphicPath = GraphicsPath;
            using Pen pen = new Pen(Color, LineWidth)
            {
                DashStyle = this.DashStyle,
            };
            graphics.DrawPath(pen, graphicPath);
        }

        public override bool IsHit(Point point)
        {
            bool res = false;
            using GraphicsPath graphicPath = GraphicsPath;
            using Pen pen = new Pen(Color, LineWidth + 3);
            res = graphicPath.IsOutlineVisible(point, pen);
            return res;
        }

        public override void Move(Point distance)
        {
            this.Start = new Point(Start.X + distance.X, Start.Y + distance.Y);
            this.End = new Point(End.X + distance.X, End.Y + distance.Y);
        }
    }
}