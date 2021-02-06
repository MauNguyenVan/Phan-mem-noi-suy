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

# nullable enable

namespace Paint.Views
{
    public partial class FrmMain : Form
    {
        private PaintType paintType;
        private Graphics graphics = default;
        private Pen pen;
        private float zoom = 1;

        // private Brush brush;
        private Color color = Color.Black;

        private List<Line> lines = new List<Line>();
        private List<FreeLine> freeLines = new List<FreeLine>();
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
            paintType = PaintType.None;
            this.WindowState = FormWindowState.Maximized;

            graphics = pnPaint.CreateGraphics();
        }

        private void pnPaint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            switch (paintType)
            {
                case PaintType.Line:

                    //graphics.DrawLine(pen, startPoint, endPoint);
                    foreach (var ln in lines)
                    {
                        pen.Color = ln.Color;
                        pen.Width = ln.LineWidth;
                        pen.DashStyle = ln.DashStyle;

                        ln.Draw(graphics);
                    }

                    break;

                case PaintType.FreeLine:

                    break;

                case PaintType.Rectangle:
                    break;

                case PaintType.Circle:
                    break;

                case PaintType.None:

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
            paintType = PaintType.Line;
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
            //pen.Width = Width;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graphics.Clear(pnPaint.BackColor);
            lines.Clear();
            lsbElement.Items.Clear();
            this.proGrid.SelectedObject = null;
            this.proGrid.Refresh();
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
                if (paintType == PaintType.Line && startPoint != endPoint)
                {
                    line = new Line(startPoint, endPoint, color, decimal.ToInt32(numLightWidth.Value))
                    {
                        IsSelected = false,
                        DashStyle = pen.DashStyle,
                    };
                    lines.Add(line);
                    this.pnPaint.Update();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pnPaint.Cursor = Cursors.Default;
            }
        }

        private Rectang rectang;

        private void pnPaint_MouseMove(object sender, MouseEventArgs e)
        {
            endPoint = e.Location;
            List<Point> freelines = new List<Point>();
            if (e.Button == MouseButtons.Left
                && paintType == PaintType.Line
                && startPoint != endPoint)
            {
                // this.Cursor = new Cursor(Cursor.Current.Handle);
                //  Cursor.Position =e.Location ;// new Point(startPoint.X, endPoint.Y);
                // endPoint = Cursor.Position;
                // Cursor.Clip = new Rectangle(this.Location, this.Size);
                Line newLine = new Line(startPoint, endPoint, color, 3);
                newLine.Draw(graphics);
                this.pnPaint.Update();
            }
            else if (e.Button == MouseButtons.Left && paintType == PaintType.FreeLine)
            {
                // graphics.DrawLine(pen, startPoint, endPoint);
                freelines.Add(startPoint);
                startPoint = endPoint;

                // pnPaint.Invalidate();
            }
            else if (paintType == PaintType.None)
            {
                rectang = new Rectang(startPoint, endPoint);

                rectang.Pen = pen;
                rectang.Draw(graphics);
                this.pnPaint.Invalidate();
            }
            freeLines.Add(new FreeLine(freelines.ToArray()));
        }

        private void pnPaint_Resize(object sender, EventArgs e)
        {
            pnPaint.CreateGraphics();
        }

        private void PnPaint_MouseWheel(object sender, MouseEventArgs e)
        {
            //  graphics.RenderingOrigin = e.Location;
            ClearAllSelection();
            if (e.Delta > 0)
            {
                zoom = 1.1f;
            }
            else if (e.Delta < 0)
            {
                if (0.5f * zoom > 0.1)
                {
                    zoom = 0.9f;
                }
            }

            graphics.ScaleTransform(zoom, zoom, MatrixOrder.Prepend);
            pnPaint.Invalidate();
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
                for (int i = selectedItems.Count + selectedIndex - 1; i >= selectedIndex; i--)
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
            paintType = PaintType.None;
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
                this.proGrid.SelectedObjects = lines.Where(x => x.IsSelected).ToArray();
            }
        }

        private bool SelectListBox(ref int i)
        {
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            i++;
        }

        private void pproGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pnPaint.Invalidate();
        }

        private void pnPaint_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void btnFreeLine_Click(object sender, EventArgs e)
        {
            paintType = PaintType.FreeLine;
        }

        private void proGrid_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test1");
        }

        private void proGrid_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void ClearAllSelection()
        {
            lsbElement.ClearSelected();
            for (int i = 0; i < lsbElement.Items.Count; i++)
            {
                lines[i].IsSelected = false;
            }
        }
    }
}