using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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
        int i=1000;
        public FrmMain()
        {
            InitializeComponent();
            graphics = pnPaint.CreateGraphics();
            pen = new Pen(Color.Black);
        }

        private void pnPaint_Paint(object sender, PaintEventArgs e)
        {
            switch (paintType)
            {
                case PaintTypeEnumeration.Line:
                   Line line = new Line(100, 100, i, 110);
                    lines.Add(line);
                    graphics.DrawLine(pen, line.X1, line.Y1, line.X2, line.Y2);
                   
                    break;
                case PaintTypeEnumeration.Rectangle:
                    break;
                case PaintTypeEnumeration.Circle:
                    break;
              
                default:
                    break;
            }
                      
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            paintType = PaintTypeEnumeration.None;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            i += 100;
            paintType = PaintTypeEnumeration.Line;

            this.pnPaint.Invalidate();
            this.Text = Line.Count.ToString();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
          if(  colorDialog.ShowDialog()==DialogResult.OK)
            {
                color = colorDialog.Color;
                UpdatePenColor();
            }

        }
        private void UpdatePenColor()
        {
            pen.Color = color;
        }
    }
}
