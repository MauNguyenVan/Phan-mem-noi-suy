using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Paint.DataClass
{
    internal class Line : Shape
    {
        public Point Middle { get; set; }
        public double Length { get; set; }
        private Point boudingStart;
        private Point boundingEnd;
        public Line()
        {
            this.Name = PaintType.Line.ToString();
        }

        public Line(Point start, Point end, Color color, int lineWidth)
        {
            this.Name = PaintType.Line.ToString();
            this.Start = start;
            this.End = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            boudingStart = Utils.GetBounding(Start, End).TopLeft;
            boundingEnd = Utils.GetBounding(Start, End).BottomDown;
            Middle = GetMiddlePoint();
        }
        internal (Point TopLeft, Point BottomDown) GetBounding()
        {
            return (boudingStart, boundingEnd);
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
        public void FillDraw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
        public override void Draw(Graphics graphics)
        {
            //  using GraphicsPath graphicPath = GraphicsPath;
            const int size = 6;
            if (IsSelected)
            {
                int minSize = LineWidth <= 3 ? 3 : LineWidth + 2;
                using Pen pen = new Pen(Color.Yellow, minSize)
                {
                    DashStyle = this.DashStyle,
                };
                SolidBrush newSolidBrush = new SolidBrush(Color.Yellow);
                graphics.DrawPath(pen, GraphicsPath);
                Rectang square = new Rectang();
                square.SolidBrush = newSolidBrush;
                square.DrawFromCenter(graphics, Start, size, size);
                square.DrawFromCenter(graphics, End, size, size);
                square.DrawFromCenter(graphics, Middle, size, size);
                Pen penRec = new Pen(Color.Gray) { DashStyle = DashStyle.Dash };
                Rectang rectang = new Rectang(this.Start, this.End)
                {
                    Pen = penRec,
                };
                rectang.Draw(graphics);

                // rectang.FillDraw(graphics);
                Textx txtS = new Textx(graphics, Start, Start.ToString(), GetAngleLine());
                Textx txtE = new Textx(graphics, End, End.ToString(), GetAngleLine());
                Textx txtL = new Textx(graphics, Middle, $"Length={ GetLengthLine()};\nAngle ={GetAngleLine()};\nWidth={this.LineWidth}", GetAngleLine());

            }
            else
            {
                using Pen pen = new Pen(Color, LineWidth)
                {
                    DashStyle = this.DashStyle,
                };
                graphics.DrawPath(pen, GraphicsPath);
            }
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

        private double GetLengthLine()
        {
            double x2 = Math.Pow(this.End.X - this.Start.X, 2);
            double y2 = Math.Pow(this.End.Y - this.Start.Y, 2);
            return Math.Sqrt(x2 + y2);
        }
    }
}