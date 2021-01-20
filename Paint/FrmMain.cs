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

        // private Brush brush;
        private Color color = Color.Black;

        private List<Line> lines = new List<Line>();
        private Line line;
        private Point startPoint, endPoint;

        public FrmMain()
        {
            InitializeComponent();
            pen = new Pen(color);

            foreach (string style in Enum.GetNames(typeof(DashStyle)))
            {
                cbxLineType.Items.Add(style);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            paintType = PaintTypeEnumeration.None;
            this.WindowState = FormWindowState.Maximized;

            graphics = pnPaint.CreateGraphics();
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
                        if (ln.IsSelected)
                        {
                            Pen newPen = new Pen(Color.YellowGreen, ln.LineWidth + 3)
                            {
                                DashStyle = ln.DashStyle
                            };

                            SolidBrush newSolidBrush = new SolidBrush(Color.Yellow);
                            graphics.DrawLine(newPen, ln.Start, ln.End);
                            //Caculator center of Circle
                            int minRadius = ln.LineWidth <= 3 ? 3 : ln.LineWidth;
                            DrawSquare(graphics, newSolidBrush, ln.Start, minRadius);
                            DrawSquare(graphics, newSolidBrush, ln.End, minRadius);

                            static void DrawSquare(Graphics graphics, SolidBrush solidBrush, Point point, int width)
                            {
                                Point startP = new Point(point.X - (int)(0.5 * width), point.Y - (int)(0.5 * width));
                                //   Point endP = new Point(point.X + radius, point.Y + radius);
                                Size size = new Size(width, width);
                                Rectangle rectangle = new Rectangle(startP, size);
                                graphics.FillRectangle(solidBrush, rectangle);
                            }
                        }
                        else
                        {
                            pen.DashStyle = ln.DashStyle;
                            graphics.DrawLine(pen, ln.Start, ln.End);
                        }
                    }

                    break;

                case PaintTypeEnumeration.Rectangle:
                    break;

                case PaintTypeEnumeration.Circle:
                    break;

                default:
                    break;
            }
            // graphics.Flush();
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
                // btnColor.BackColor = color;
                btnColor.ForeColor = color;
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
                    line = new Line(startPoint, endPoint, color, decimal.ToInt32(numLightWidth.Value))
                    {
                        IsSelected = false,
                        DashStyle = pen.DashStyle,
                    };
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
            Delete();
        }

        private void Delete()
        {
            ListBox.SelectedObjectCollection selectedItems = lsbElement.SelectedItems;
            int selectedIndex = lsbElement.SelectedIndex;
            if (lsbElement.SelectedIndex != -1)
            {
                for (int i = selectedIndex; i < selectedItems.Count; i++)
                {
                    MessageBox.Show(lsbElement.SelectedIndex.ToString(), i.ToString());
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
            //  this.pnPaint.Invalidate();
        }

        private void lsbElement_DoubleClick(object sender, EventArgs e)
        {
            Delete();
        }

        private void cbxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pen.DashStyle = (DashStyle)cbxLineType.SelectedIndex;
        }

        private void lsbElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = lsbElement.SelectedItems;
            int selectedIndex = lsbElement.SelectedIndex;
            if (lsbElement.SelectedIndex != -1)
            {
                //for (int i = selectedIndex; i < selectedItems.Count; i++)
                //{
                //    lines[i].IsSelected = true;
                //}
                for (int i = 0; i < lsbElement.Items.Count; i++)
                {
                    if (i >= selectedIndex && i < selectedIndex + selectedItems.Count)
                    {
                        lines[i].IsSelected = true;
                    }
                    else
                    {
                        lines[i].IsSelected = false;
                    }
                }
                pnPaint.Invalidate();
            }
        }
    }
}