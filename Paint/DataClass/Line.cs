using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Text;
using System.Windows;

#nullable enable

namespace Paint.DataClass
{
    internal class Line : Shape
    {
        private Point start;
        private Point end;

        [Category(Categories.LOCATION)]
        public override Point Start
        {
            get
            { return start; }
            set
            {
                start = value;
                UpdateProperties();
            }
        }

        [Category(Categories.LOCATION)]
        public override Point End
        {
            get
            { return end; }
            set
            {
                end = value;
                UpdateProperties();
            }
        }

        [Category(Categories.LOCATION)]
        public Point Middle
        {
            get; private set;
        }

        [Category(Categories.PROPERTIES)]
        public float Length { get; private set; }

        [Category(Categories.PROPERTIES)]
        public float Angle { get; private set; }

        internal BoundingBox BoundingBox { get; }

        public Line(Pen pen, Point start, Point end)
        {
            if (start != end)
            {
                this.IsVisible = true;
                this.Name = PaintType.Line.ToString();
                this.Start = start;
                this.End = end;
                this.Pen = pen;

                this.BoundingBox = new BoundingBox(new Point[] { Start, End });

                UpdateProperties();
            }
        }

        private void UpdateProperties()
        {
            Middle = GetMiddlePoint();
            this.Length = GetLengthLine();
            this.Angle = GetAngleLine();
        }

        public bool IsVertical()
        {
            bool isVertical = false;
            if (Start.X == End.X)
            {
                isVertical = true;
            }
            return isVertical;
        }

        public bool IsHorizontal()
        {
            bool isHorizontal = false;
            if (Start.X == End.X)
            {
                isHorizontal = true;
            }
            return isHorizontal;
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

        public void FillDraw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics)
        {
            //  using GraphicsPath graphicPath = GraphicsPath;
            if (IsVisible)
            {
                const int size = Shape.SizePointHighlight;
                if (IsSelected)
                {
                    int minSize = Pen.Width <= 3 ? 3 : (int)Pen.Width + 2;
                    using Pen pen = new Pen(Color.Yellow, minSize)
                    {
                        DashStyle = this.DashStyle,
                    };
                    SolidBrush newSolidBrush = new SolidBrush(Color.Yellow);
                    graphics.DrawPath(pen, GraphicsPath);

                    // Rectang.SolidBrush = newSolidBrush;
                    Rectang.DrawFromCenter(graphics, Start, size, size);
                    Rectang.DrawFromCenter(graphics, End, size, size);
                    Rectang.DrawFromCenter(graphics, Middle, size, size);
                    Pen penRec = new Pen(Color.Gray) { DashStyle = DashStyle.Dash };
                    Rectang rectang = new Rectang(this.Start, this.End)
                    {
                        Pen = penRec,
                    };
                    rectang.Draw(graphics);

                    // rectang.FillDraw(graphics);
                    Text txtS = new Text(graphics, Start, Start.ToString(), Angle);
                    Text txtE = new Text(graphics, End, End.ToString(), Angle);
                    Text txtL = new Text(graphics, Middle, $"Length={ this.Length};\nAngle ={Angle};\nWidth={this.Pen.Width}", Angle);
                }
                else
                {
                    graphics.DrawPath(Pen, GraphicsPath);
                }
            }
        }

        //public override bool IsHit(Point point)
        ////{
        ////    using GraphicsPath graphicPath = GraphicsPath;
        ////    using Pen pen = new Pen(Color, LineWidth + 3);
        ////    bool res = graphicPath.IsOutlineVisible(point, pen);
        //   // return res;
        //}

        public override void Move(Point distance)
        {
            this.Start = new Point(Start.X + distance.X, Start.Y + distance.Y);
            this.End = new Point(End.X + distance.X, End.Y + distance.Y);
        }

        public static float GetAngleTwoPoint(PointF p1, PointF p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return (float)(Math.Atan2(yDiff, xDiff) * (180 / Math.PI));
        }

        public static float GetLenghtTwoPoint(PointF p1, PointF p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return (float)(Math.Atan2(yDiff, xDiff) * (180 / Math.PI));
        }

        public float GetAngleLine()
        {
            Point p1 = this.Start;
            Point p2 = this.End;
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return (float)(Math.Atan2(yDiff, xDiff) * (180 / Math.PI));
        }

        private Point GetMiddlePoint()
        {
            int middleX = (int)(0.5 * (this.Start.X + this.End.X));
            int middleY = (int)(0.5 * (this.Start.Y + this.End.Y));
            return new Point(middleX, middleY);
        }

        private float GetLengthLine()
        {
            double x2 = Math.Pow(this.End.X - this.Start.X, 2);
            double y2 = Math.Pow(this.End.Y - this.Start.Y, 2);
            return (float)Math.Sqrt(x2 + y2);
        }
    }
}