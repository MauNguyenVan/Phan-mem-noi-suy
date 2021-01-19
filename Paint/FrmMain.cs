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
        private Line line;
        private Point startPoint, endPoint;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            paintType = PaintTypeEnumeration.None;

            graphics = pnPaint.CreateGraphics();
            pen = new Pen(Color.Black);
        }

        private void pnPaint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            switch (paintType)
            {
                case PaintTypeEnumeration.Line:
                    //graphics.DrawLine(pen, startPoint, endPoint);
                    foreach (var ln in lines)
                    {
                        pen.Color = ln.Color;
                        pen.Width = ln.LineWidth;
                        graphics.DrawLine(pen, ln.Start, ln.End);
                    }

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
            lsbElement.Items.Clear();
            lsbElement.Items.AddRange(lines.ToArray());
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
            graphics.Clear(pnPaint.BackColor);
            lines.Clear();
            lsbElement.Items.Clear();
        }

        private void pnPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                pnPaint.Cursor = Cursors.Default;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pnPaint.Cursor = Cursors.SizeAll;
            }

            // this.pnPaint.Invalidate();
        }

        private void pnPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;
                if (paintType == PaintTypeEnumeration.Line)
                {
                    line = new Line(startPoint, endPoint, color, decimal.ToInt32(numLightWidth.Value));
                    lines.Add(line);
                    this.pnPaint.Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pnPaint.Cursor = Cursors.Default;
            }
        }

        private void pnPaint_MouseMove(object sender, MouseEventArgs e)
        {
            endPoint = e.Location;
            //   this.pnPaint.Invalidate();
        }

        private void pnPaint_Resize(object sender, EventArgs e)
        {
            pnPaint.CreateGraphics();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //this.Text = lsbElement.SelectedItem.ToString();
            var selectedItems = lsbElement.SelectedItems;
            if (lsbElement.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    lsbElement.Items.RemoveAt(i);
                    lines.RemoveAt(i);
                }
            }

            lsbElement.Items.Clear();
            lsbElement.Items.AddRange(lines.ToArray());

            this.pnPaint.Invalidate();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            paintType = PaintTypeEnumeration.None;
        }

        private void lsbElement_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}