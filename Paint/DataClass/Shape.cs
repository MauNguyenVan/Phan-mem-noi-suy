using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
    internal class Shape
    {
        protected const int SizePointHighlight = 6;
        internal static int CurrentId = 0;
        [Category(Categories.IDENTITY)]
        [Description("Id of element")]
        public int Id { get; protected set; }
        [Category(Categories.IDENTITY)]
        public string Name { get; protected set; } = "Unknow";
        [Category(Categories.LOCATION)]
        public virtual Point Start { get; set; }
        [Category(Categories.LOCATION)]
        public virtual Point End { get; set; }
        [Category(Categories.GRAPHICS)]
        public Color Color { get; set; }
        [Category(Categories.GRAPHICS)]
        public Pen Pen { get; set; }
        [Category(Categories.GRAPHICS)]
        public SolidBrush SolidBrush { get; set; }
        /// <summary>
        /// Chieu day line
        /// </summary>
        [Category(Categories.GRAPHICS)]
        public int LineWidth { get; set; }
        [Category(Categories.GRAPHICS)]
        public DashStyle DashStyle { get; set; } = DashStyle.Solid;
        [Category(Categories.PROPERTIES)]
        public bool IsSelected { get; internal set; }
        [Category(Categories.PROPERTIES)]
        public bool IsVisible { get; set; }
        [Category(Categories.PROPERTIES)]
        protected virtual GraphicsPath GraphicsPath { get; }
        [Category(Categories.PROPERTIES)]
        public virtual bool IsHit(Point point) { return false; }

        public virtual void Draw(Graphics graphics) { }
        // public virtual void FillDraw(Graphics graphics) { }
        public virtual void Move(Point distance) { }

        public virtual object Clone() { return new object(); }

        public override string ToString()
        {
            return $"{Name} [({Start.X},{Start.Y});({End.X},{End.Y})]";
        }
    }
}