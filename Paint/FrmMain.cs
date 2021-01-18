using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint.DataClass;

namespace Paint
{
    public partial class FrmMain : Form
    {
        private PaintTypeEnumeration paintType;
        private Graphics graphics = default;
        private Pen pen;
        private Color color;
        private List<Line> lines = new List<Line>();
        private int i = 1000;

        public FrmMain()
        {
            InitializeComponent();
            graphics = pnPaint.CreateGraphics();
            pen = new Pen(Color.Black);
        }

        private void pnPaint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            switch (paintType)
            {
                case PaintTypeEnumeration.Line:
                    graphics.DrawLine(pen, line.Start, line.End);
                    break;

                case PaintTypeEnumeration.Rectangle:
                    break;

                case PaintTypeEnumeration.Circle:
                    break;

                default:
                    break;
            }
            graphics.Flush();
            //  graphics.Dispose();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            paintType = PaintTypeEnumeration.None;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.pnPaint.Invalidate();
            paintType = PaintTypeEnumeration.Line;

           

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                UpdatePenColor();
            }
        }

        private void UpdatePenColor()
        {
            pen.Color = color;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // graphics.Clear();
        }
        Line line = new Line();
        private void pnPaint_MouseDown(object sender, MouseEventArgs e)
        {
            line.Start = e.Location;
           // this.pnPaint.Invalidate();
        }

        private void pnPaint_MouseUp(object sender, MouseEventArgs e)
        {
            line.End = e.Location;
            //this.pnPaint.Invalidate();
        }

        private void pnPaint_MouseMove(object sender, MouseEventArgs e)
        {
            line.End = e.Location;
            this.pnPaint.Invalidate();
        }
    }
}