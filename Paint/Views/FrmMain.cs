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
        private bool isMouseDown;

        // private Brush brush;
        private Color color = Color.Black;

        private List<Shape> shapes = new List<Shape>();

        private Line line;
        private Point startPoint, endPoint;

        public FrmMain()
        {
            InitializeComponent();
            pnPaint.BackColor = default;

            //pnPaint.AutoScroll = true;
            //pnPaint.HorizontalScroll.Enabled = true;
            //pnPaint.HorizontalScroll.Visible = true;
            // pnPaint.HorizontalScroll.Maximum = 0;
            pnPaint.AutoScroll = true;
            pen = new Pen(color);

            foreach (string style in Enum.GetNames(typeof(DashStyle)))
            {
                cbxLineType.Items.Add(style);
            }
            cbxLineType.SelectedIndex = 0;
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
                    foreach (var ln in shapes)
                    {
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
            lsbElement.Items.AddRange(shapes.ToArray());
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
            pen.Width = decimal.ToInt32(numLightWidth.Value);
            pen.DashStyle = (DashStyle)cbxLineType.SelectedIndex;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graphics.Clear(pnPaint.BackColor);
            shapes.Clear();
            lsbElement.Items.Clear();
            this.proGrid.SelectedObject = null;
            this.proGrid.Refresh();
        }

        private void pnPaint_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            // lsbElement.SelectedItem = null;
            //pnPaint.Invalidate();
            // proGrid.Update();
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
            isMouseDown = false;
            endPoint = e.Location;
            bool mouseLocationChange = startPoint != endPoint ? true : false;
            if (e.Button == MouseButtons.Left && mouseLocationChange)
            {
                if (paintType == PaintType.Line)
                {
                    line = new Line(pen, startPoint, endPoint)
                    {
                        IsSelected = false,
                    };
                    shapes.Add(line);
                }
                pnPaint.Refresh();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pnPaint.Cursor = Cursors.Default;
            }
        }

        private void pnPaint_MouseMove(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            endPoint = e.Location;
            List<Point> freelines = new List<Point>();
            if (e.Button == MouseButtons.Left)
            {
                if (paintType == PaintType.Line)
                {
                    pnPaint.Refresh();
                    graphics.DrawLine(pen, startPoint, endPoint);

                    // graphics.DrawLine(pen, startPoint, endPoint);

                    //this.pnPaint.Invalidate();
                    //  this.pnPaint.Update();
                }
                else if (paintType == PaintType.FreeLine)
                {
                    // graphics.DrawLine(pen, startPoint, endPoint);
                    //   freelines.Add(startPoint);
                    // startPoint = endPoint;

                    // pnPaint.Invalidate();
                }
                else if (paintType == PaintType.None)
                {
                    //rectang = new Rectang(startPoint, endPoint);

                    //rectang.Pen = pen;
                    //rectang.Draw(graphics);
                    //this.pnPaint.Invalidate();
                }
                //  shapes.Add(new FreeLine(freelines.ToArray()));
            }
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
                    shapes.RemoveAt(i);
                }
            }
            lsbElement.Items.Clear();
            lsbElement.Items.AddRange(shapes.ToArray());
            this.pnPaint.Invalidate();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            paintType = PaintType.Rectangle;
            //  this.pnPaint.Invalidate();
        }

        private void lsbElement_DoubleClick(object sender, EventArgs e)
        {
            Delete();
        }

        private void cbxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePenColor();
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
                        shapes[i].IsSelected = true;
                    }
                    else
                    {
                        shapes[i].IsSelected = false;
                    }
                }

                pnPaint.Invalidate();
                this.proGrid.SelectedObjects = shapes.Where(x => x.IsSelected).ToArray();
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

        private void proGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pnPaint.Invalidate();
            proGrid.Refresh();
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

        private void numLightWidth_ValueChanged(object sender, EventArgs e)
        {
            UpdatePenColor();
        }

        private void ClearAllSelection()
        {
            lsbElement.ClearSelected();
            for (int i = 0; i < lsbElement.Items.Count; i++)
            {
                shapes[i].IsSelected = false;
            }
        }
    }
}