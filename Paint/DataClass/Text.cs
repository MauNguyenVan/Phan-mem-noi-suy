using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Paint.DataClass
{
    internal class Text
    {
       
        public Graphics Graphics { get; set; }
        public string Content { get; set; } = string.Empty;
        public Font Font { get; set; } = new Font("Arial", 12);
        public Point Point { get; set; }
        public SolidBrush SolidBrush { get; set; } = new SolidBrush(Color.Black);
        public StringFormat stringFormat = new StringFormat();
        public float TextAngle { get; set; } = 0f;

        public Text(Graphics graphics, Point point, string content, float textAngle=0f)
        {
            this.Graphics = graphics;
            this.Point = point;
            Content = content;
            this.TextAngle = textAngle;
            DrawString();
        }

        public void DrawString()
        {
            //Graphics.ResetTransform();
            // stringFormat.

            // Graphics.TranslateTransform(Point.X, Point.Y, MatrixOrder.Prepend);
            // Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            // Graphics.TranslateTransform(Graphics.Width / 2 - 30, this.Height / 2 - 30);

            // Graphics.RotateTransform(TextAngle);
            // Graphics.TranslateTransform(Point.X, Point.Y);
            Graphics.DrawString(Content, Font, SolidBrush, Point, stringFormat);
          
            Graphics.ResetTransform();
            Font.Dispose();
            SolidBrush.Dispose();
            //  Graphics.Dispose();
        }
    }
}