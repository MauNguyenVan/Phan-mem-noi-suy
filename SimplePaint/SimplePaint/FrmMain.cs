using SimplePaint.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class FrmMain : Form
    {
        #region Properties
        private List<Button> buttons;
        private List<Shape> shapes = new List<Shape>();
        private CurrentShape currentShape = CurrentShape.NoDrawing;
        private Point previousPoint;
        private ShapeMode mode = ShapeMode.NoFill;
        private Brush brush = new SolidBrush(Color.Blue);
        private Pen framePen = new Pen(Color.Blue, 1)
        {
            DashPattern = new float[] { 3, 3, 3, 3 },
            DashStyle = DashStyle.Custom
        };
        private Shape selectedShape;
        private System.Drawing.Rectangle selectedRegion;
        private bool isMouseDown;
        private bool isDrawCurve;
        private bool isDrawPolygon;
        private bool isDrawBezier;
        private bool isMovingShape;
        private bool isControlKeyPress;
        private bool isMouseSelect;
        private int movingOffset;
        #endregion

        #region Constructor
        public FrmMain()
        {
            InitializeComponent();

            buttons = new List<Button> { btnBezier, btnCircle, btnCurve, btnEllipse, btnLine, btnPolygon, btnRectangle, btnSelect, btnSquare };
            cmbShapeMode.SelectedIndex = 0;
            cmbDashMode.SelectedIndex = 0;
        }
        #endregion

        #region Function
        /// <summary>
        /// Bỏ chọn hết các button
        /// </summary>
        private void UncheckAll()
        {
            buttons.ForEach(button => button.BackColor = Color.Transparent);
        }

        /// <summary>
        /// Tìm cái khung chứa đường cong này
        /// </summary>
        /// <param name="curve">Đường cong cần tìm cái khung</param>
        private void FindCurveRegion(Curve curve)
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            curve.Points.ForEach(p =>
            {
                if (minX > p.X)
                {
                    minX = p.X;
                }
                if (minY > p.Y)
                {
                    minY = p.Y;
                }
                if (maxX < p.X)
                {
                    maxX = p.X;
                }
                if (maxY < p.Y)
                {
                    maxY = p.Y;
                }
            });
            curve.Begin = new Point(minX, minY);
            curve.End = new Point(maxX, maxY);
        }

        /// <summary>
        /// Tìm cái khung chứa đa giác này
        /// </summary>
        /// <param name="polygon">Đa giác cần tìm cái khung</param>
        private void FindPolygonRegion(Polygon polygon)
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            polygon.Points.ForEach(p =>
            {
                if (minX > p.X)
                {
                    minX = p.X;
                }
                if (minY > p.Y)
                {
                    minY = p.Y;
                }
                if (maxX < p.X)
                {
                    maxX = p.X;
                }
                if (maxY < p.Y)
                {
                    maxY = p.Y;
                }
            });
            polygon.Begin = new Point(minX, minY);
            polygon.End = new Point(maxX, maxY);
        }

        /// <summary>
        /// Kích hoạt các button
        /// </summary>
        private void EnableButtons()
        {
            buttons.ForEach(button => button.Enabled = true);
        }

        /// <summary>
        /// Tìm cái khung chứa group này
        /// </summary>
        /// <param name="group">Group cần tìm cái khung</param>
        private void FindGroupRegion(Group group)
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;

            for (int i = 0; i < group.Count; i++)
            {
                Shape shape = group[i];

                if (shape is Curve curve)
                {
                    FindCurveRegion(curve);
                }
                else if (shape is Polygon polygon)
                {
                    FindPolygonRegion(polygon);
                }


                if (shape.Begin.X < minX)
                {
                    minX = shape.Begin.X;
                }
                if (shape.End.X < minX)
                {
                    minX = shape.End.X;
                }

                if (shape.Begin.Y < minY)
                {
                    minY = shape.Begin.Y;
                }
                if (shape.End.Y < minY)
                {
                    minY = shape.End.Y;
                }

                if (shape.Begin.X > maxX)
                {
                    maxX = shape.Begin.X;
                }
                if (shape.End.X > maxX)
                {
                    maxX = shape.End.X;
                }

                if (shape.Begin.Y > maxY)
                {
                    maxY = shape.Begin.Y;
                }
                if (shape.End.Y > maxY)
                {
                    maxY = shape.End.Y;
                }
            }
            group.Begin = new Point(minX, minY);
            group.End = new Point(maxX, maxY);
        }

        /// <summary>
        /// Di chuyển các hình đã chọn
        /// </summary>
        /// <param name="action">Hướng di chuyển</param>
        private void MoveShape(Action<int> action)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].IsSelected)
                {
                    action(i);
                }
            }
            psfMain.Invalidate();
        }

        /// <summary>
        /// Di chuyển hình ở vị trí index sang phải
        /// </summary>
        /// <param name="index">Vị trí của hình</param>
        private void ToRight(int index)
        {
            Shape shape = shapes[index];
            if (shape is Curve curve)
            {
                for (int j = 0; j < curve.Points.Count; j++)
                {
                    curve.Points[j] = new Point(curve.Points[j].X + movingOffset, curve.Points[j].Y);
                }
            }
            else if (shape is Polygon polygon)
            {
                for (int j = 0; j < polygon.Points.Count; j++)
                {
                    polygon.Points[j] = new Point(polygon.Points[j].X + movingOffset, polygon.Points[j].Y);
                }
            }
            else if (shape is Group group)
            {
                for (int i = 0; i < group.Count; i++)
                {
                    Shape s = group[i];
                    if (s is Curve c)
                    {
                        for (int j = 0; j < c.Points.Count; j++)
                        {
                            c.Points[j] = new Point(c.Points[j].X + movingOffset, c.Points[j].Y);
                        }
                    }
                    else if (s is Polygon p)
                    {
                        for (int j = 0; j < p.Points.Count; j++)
                        {
                            p.Points[j] = new Point(p.Points[j].X + movingOffset, p.Points[j].Y);
                        }
                    }
                    s.Begin = new Point(s.Begin.X + movingOffset, s.Begin.Y);
                    s.End = new Point(s.End.X + movingOffset, s.End.Y);
                }
            }
            shape.Begin = new Point(shape.Begin.X + movingOffset, shape.Begin.Y);
            shape.End = new Point(shape.End.X + movingOffset, shape.End.Y);
        }

        /// <summary>
        /// Di chuyển hình ở vị trí index lên trên
        /// </summary>
        /// <param name="index">Vị trí của hình</param>
        private void ToUp(int index)
        {
            Shape shape = shapes[index];
            if (shape is Curve curve)
            {
                for (int j = 0; j < curve.Points.Count; j++)
                {
                    curve.Points[j] = new Point(curve.Points[j].X, curve.Points[j].Y - movingOffset);
                }
            }
            else if (shape is Polygon polygon)
            {
                for (int j = 0; j < polygon.Points.Count; j++)
                {
                    polygon.Points[j] = new Point(polygon.Points[j].X, polygon.Points[j].Y - movingOffset);
                }
            }
            else if (shape is Group group)
            {
                for (int i = 0; i < group.Count; i++)
                {
                    Shape s = group[i];
                    if (s is Curve c)
                    {
                        for (int j = 0; j < c.Points.Count; j++)
                        {
                            c.Points[j] = new Point(c.Points[j].X, c.Points[j].Y - movingOffset);
                        }
                    }
                    else if (s is Polygon p)
                    {
                        for (int j = 0; j < p.Points.Count; j++)
                        {
                            p.Points[j] = new Point(p.Points[j].X, p.Points[j].Y - movingOffset);
                        }
                    }
                    s.Begin = new Point(s.Begin.X, s.Begin.Y - movingOffset);
                    s.End = new Point(s.End.X, s.End.Y - movingOffset);
                }
            }
            shape.Begin = new Point(shape.Begin.X, shape.Begin.Y - movingOffset);
            shape.End = new Point(shape.End.X, shape.End.Y - movingOffset);
        }

        /// <summary>
        /// Di chuyển hình ở vị trí index xuống dưới
        /// </summary>
        /// <param name="index">Vị trí của hình</param>
        private void ToDown(int index)
        {
            Shape shape = shapes[index];
            if (shape is Curve curve)
            {
                for (int j = 0; j < curve.Points.Count; j++)
                {
                    curve.Points[j] = new Point(curve.Points[j].X, curve.Points[j].Y + movingOffset);
                }
            }
            else if (shape is Polygon polygon)
            {
                for (int j = 0; j < polygon.Points.Count; j++)
                {
                    polygon.Points[j] = new Point(polygon.Points[j].X, polygon.Points[j].Y + movingOffset);
                }
            }
            else if (shape is Group group)
            {
                for (int i = 0; i < group.Count; i++)
                {
                    Shape s = group[i];
                    if (s is Curve c)
                    {
                        for (int j = 0; j < c.Points.Count; j++)
                        {
                            c.Points[j] = new Point(c.Points[j].X, c.Points[j].Y + movingOffset);
                        }
                    }
                    else if (s is Polygon p)
                    {
                        for (int j = 0; j < p.Points.Count; j++)
                        {
                            p.Points[j] = new Point(p.Points[j].X, p.Points[j].Y + movingOffset);
                        }
                    }
                    s.Begin = new Point(s.Begin.X, s.Begin.Y + movingOffset);
                    s.End = new Point(s.End.X, s.End.Y + movingOffset);
                }
            }
            shape.Begin = new Point(shape.Begin.X, shape.Begin.Y + movingOffset);
            shape.End = new Point(shape.End.X, shape.End.Y + movingOffset);
        }

        /// <summary>
        /// Di chuyển hình ở vị trí index sang trái
        /// </summary>
        /// <param name="index">Vị trí của hình</param>
        private void ToLeft(int index)
        {
            Shape shape = shapes[index];
            if (shape is Curve curve)
            {
                for (int j = 0; j < curve.Points.Count; j++)
                {
                    curve.Points[j] = new Point(curve.Points[j].X - movingOffset, curve.Points[j].Y);
                }
            }
            else if (shape is Polygon polygon)
            {
                for (int j = 0; j < polygon.Points.Count; j++)
                {
                    polygon.Points[j] = new Point(polygon.Points[j].X - movingOffset, polygon.Points[j].Y);
                }
            }
            else if (shape is Group group)
            {
                for (int i = 0; i < group.Count; i++)
                {
                    Shape s = group[i];
                    if (s is Curve c)
                    {
                        for (int j = 0; j < c.Points.Count; j++)
                        {
                            c.Points[j] = new Point(c.Points[j].X - movingOffset, c.Points[j].Y);
                        }
                    }
                    else if (s is Polygon p)
                    {
                        for (int j = 0; j < p.Points.Count; j++)
                        {
                            p.Points[j] = new Point(p.Points[j].X - movingOffset, p.Points[j].Y);
                        }
                    }
                    s.Begin = new Point(s.Begin.X - movingOffset, s.Begin.Y);
                    s.End = new Point(s.End.X - movingOffset, s.End.Y);
                }
            }
            shape.Begin = new Point(shape.Begin.X - movingOffset, shape.Begin.Y);
            shape.End = new Point(shape.End.X - movingOffset, shape.End.Y);
        }
        #endregion

        #region Event's action
        private void PsfMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            shapes.ForEach(shape =>
            {
                if (shape.IsSelected)
                {
                    shape.Draw(e.Graphics);
                    if (shape is Ellipse || shape is Group)
                    {
                        e.Graphics.DrawRectangle(framePen, new System.Drawing.Rectangle(shape.Begin.X, shape.Begin.Y, shape.End.X - shape.Begin.X, shape.End.Y - shape.Begin.Y));
                    }
                    else if (shape is Curve curve)
                    {
                        for (int i = 0; i < curve.Points.Count; i++)
                        {
                            e.Graphics.FillEllipse(brush, new System.Drawing.Rectangle(curve.Points[i].X - 4, curve.Points[i].Y - 4, 8, 8));
                        }
                    }
                    else if (shape is Polygon polygon)
                    {
                        for (int i = 0; i < polygon.Points.Count; i++)
                        {
                            e.Graphics.FillEllipse(brush, new System.Drawing.Rectangle(polygon.Points[i].X - 4, polygon.Points[i].Y - 4, 8, 8));
                        }
                    }
                    else
                    {
                        e.Graphics.FillEllipse(brush, new System.Drawing.Rectangle(shape.Begin.X - 4, shape.Begin.Y - 4, 8, 8));
                        e.Graphics.FillEllipse(brush, new System.Drawing.Rectangle(shape.End.X - 4, shape.End.Y - 4, 8, 8));
                    }
                }
                else
                {
                    shape.Draw(e.Graphics);
                }
            });

            if (isMouseSelect)
            {
                e.Graphics.DrawRectangle(framePen, selectedRegion);
            }
        }

        private void PsfMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentShape == CurrentShape.NoDrawing)
            {
                if (isControlKeyPress)
                {
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (shapes[i].IsHit(e.Location))
                        {
                            shapes[i].IsSelected = !shapes[i].IsSelected;
                            clbShape.SetItemChecked(i, shapes[i].IsSelected);

                            psfMain.Invalidate();
                            break;
                        }
                    }
                }
                else
                {
                    shapes.ForEach(shape => shape.IsSelected = false);
                    psfMain.Invalidate();

                    for (int i = 0; i < clbShape.Items.Count; i++)
                    {
                        clbShape.SetItemChecked(i, false);
                    }

                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (shapes[i].IsHit(e.Location))
                        {
                            selectedShape = shapes[i];
                            shapes[i].IsSelected = true;
                            clbShape.SetItemChecked(i, true);

                            if (!(shapes[i] is Group))
                            {
                                trkLineWidth.Value = shapes[i].LineWidth;
                                btnColor.BackColor = shapes[i].Color;
                                lblWidth.Text = trkLineWidth.Value.ToString();
                            }

                            psfMain.Invalidate();
                            break;
                        }
                    }

                    if (selectedShape != null)
                    {
                        isMovingShape = true;
                        previousPoint = e.Location;
                    }
                    else
                    {
                        isMouseSelect = true;
                        selectedRegion = new System.Drawing.Rectangle(e.Location, new Size(0, 0));
                    }
                }
            }
            else
            {
                isMouseDown = true;
                shapes.ForEach(shape => shape.IsSelected = false);

                if (currentShape == CurrentShape.Line)
                {
                    Line line = new Line
                    {
                        Begin = e.Location,
                        LineWidth = trkLineWidth.Value,
                        Color = btnColor.BackColor,
                        DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                    };
                    shapes.Add(line);
                }
                else if (currentShape == CurrentShape.Rectangle)
                {
                    Model.Rectangle rectangle = new Model.Rectangle
                    {
                        Begin = e.Location,
                        LineWidth = trkLineWidth.Value,
                        Color = btnColor.BackColor,
                        DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                    };

                    if (mode == ShapeMode.Fill)
                    {
                        rectangle.Fill = true;
                    }

                    shapes.Add(rectangle);
                }
                else if (currentShape == CurrentShape.Ellipse)
                {
                    Ellipse ellipse = new Ellipse
                    {
                        Begin = e.Location,
                        LineWidth = trkLineWidth.Value,
                        Color = btnColor.BackColor,
                        DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                    };

                    if (mode == ShapeMode.Fill)
                    {
                        ellipse.Fill = true;
                    }

                    shapes.Add(ellipse);
                }
                else if (currentShape == CurrentShape.Square)
                {
                    Square square = new Square
                    {
                        Begin = e.Location,
                        LineWidth = trkLineWidth.Value,
                        Color = btnColor.BackColor,
                        DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                    };

                    if (mode == ShapeMode.Fill)
                    {
                        square.Fill = true;
                    }

                    shapes.Add(square);
                }
                else if (currentShape == CurrentShape.Circle)
                {
                    Circle circle = new Circle
                    {
                        Begin = e.Location,
                        LineWidth = trkLineWidth.Value,
                        Color = btnColor.BackColor,
                        DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                    };

                    if (mode == ShapeMode.Fill)
                    {
                        circle.Fill = true;
                    }

                    shapes.Add(circle);
                }
                else if (currentShape == CurrentShape.Polygon)
                {
                    if (!isDrawPolygon)
                    {
                        Polygon polygon = new Polygon
                        {
                            LineWidth = trkLineWidth.Value,
                            Color = btnColor.BackColor,
                            DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                        };

                        if (mode == ShapeMode.Fill)
                        {
                            polygon.Fill = true;
                        }

                        polygon.Points.Add(e.Location);
                        polygon.Points.Add(e.Location);

                        shapes.Add(polygon);

                        isDrawPolygon = true;
                    }
                    else
                    {
                        Polygon polygon = shapes[shapes.Count - 1] as Polygon;

                        polygon.Points[polygon.Points.Count - 1] = e.Location;
                        polygon.Points.Add(e.Location);
                    }

                    isMouseDown = false;
                }
                else if (currentShape == CurrentShape.Curve)
                {
                    if (!isDrawCurve)
                    {
                        Curve curve = new Curve
                        {
                            LineWidth = trkLineWidth.Value,
                            Color = btnColor.BackColor,
                            DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                        };

                        curve.Points.Add(e.Location);
                        curve.Points.Add(e.Location);

                        shapes.Add(curve);

                        isDrawCurve = true;
                    }
                    else
                    {
                        Curve curve = shapes[shapes.Count - 1] as Curve;
                        curve.Points[curve.Points.Count - 1] = e.Location;

                        curve.Points.Add(e.Location);
                    }
                    isMouseDown = false;
                }
                else if (currentShape == CurrentShape.Bezier)
                {
                    if (!isDrawBezier)
                    {
                        Curve bezier = new Curve
                        {
                            LineWidth = trkLineWidth.Value,
                            Color = btnColor.BackColor,
                            DashStyle = (DashStyle)cmbDashMode.SelectedIndex
                        };
                        bezier.Points.Add(e.Location);
                        bezier.Points.Add(e.Location);

                        shapes.Add(bezier);

                        isDrawBezier = true;
                    }
                    else
                    {
                        Curve bezier = shapes[shapes.Count - 1] as Curve;
                        if (bezier.Points.Count < 4)
                        {
                            bezier.Points[bezier.Points.Count - 1] = e.Location;
                            bezier.Points.Add(e.Location);
                        }
                        else
                        {
                            isDrawBezier = false;
                            FindCurveRegion(bezier);
                        }
                    }
                    isMouseDown = false;
                }
            }
        }

        private void PsfMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                shapes[shapes.Count - 1].End = e.Location;
                psfMain.Invalidate();
            }
            else if (isMovingShape)
            {
                Point d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                selectedShape.Move(d);
                previousPoint = e.Location;

                psfMain.Invalidate();
            }
            else if (currentShape == CurrentShape.NoDrawing)
            {
                if (isMouseSelect)
                {
                    selectedRegion.Width = e.Location.X - selectedRegion.X;
                    selectedRegion.Height = e.Location.Y - selectedRegion.Y;

                    psfMain.Invalidate();
                }
                else
                {
                    if (shapes.Exists(shape => shape.IsHit(e.Location)))
                    {
                        psfMain.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        psfMain.Cursor = Cursors.Default;
                    }
                }
            }

            if (isDrawPolygon)
            {
                Polygon polygon = shapes[shapes.Count - 1] as Polygon;
                polygon.Points[polygon.Points.Count - 1] = e.Location;

                psfMain.Invalidate();
            }
            else if (isDrawCurve)
            {
                Curve curve = shapes[shapes.Count - 1] as Curve;
                curve.Points[curve.Points.Count - 1] = e.Location;

                psfMain.Invalidate();
            }
            else if (isDrawBezier)
            {
                Curve bezier = shapes[shapes.Count - 1] as Curve;
                bezier.Points[bezier.Points.Count - 1] = e.Location;

                psfMain.Invalidate();
            }
        }

        private void PsfMain_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (isMovingShape)
            {
                isMovingShape = false;
                selectedShape = null;
            }
            else if (isMouseSelect)
            {
                isMouseSelect = false;
                for (int i = 0; i < shapes.Count; i++)
                {
                    clbShape.SetItemChecked(i, false);
                    shapes[i].IsSelected = false;

                    if (shapes[i].Begin.X >= selectedRegion.X && shapes[i].End.X <= selectedRegion.X + selectedRegion.Width && shapes[i].Begin.Y >= selectedRegion.Y && shapes[i].End.Y <= selectedRegion.Y + selectedRegion.Height)
                    {
                        clbShape.SetItemChecked(i, true);
                        shapes[i].IsSelected = true;
                    }
                }

                psfMain.Invalidate();
            }

            try
            {
                Shape shape = shapes[shapes.Count - 1];

                // Đổi 2 điểm lại cho thuận nếu bị ngược
                if (shape.Begin.X > shape.End.X || (shape.Begin.X == shape.End.X && shape.Begin.Y > shape.End.Y))
                {
                    Point temp = shape.Begin;
                    shape.Begin = shape.End;
                    shape.End = temp;
                }

                if (shape is Circle circle)
                {
                    circle.End = new Point(circle.Begin.X + circle.Diameter, circle.Begin.Y + circle.Diameter);
                }
                else if (shape is Square square)
                {
                    if (square.Begin.X < square.End.X && square.Begin.Y > square.End.Y)
                    {
                        square.Begin = new Point(square.Begin.X, square.End.Y);
                        square.End = new Point(square.Begin.X + square.Width, square.Begin.Y + square.Width);
                    }
                    else
                    {
                        square.End = new Point(square.Begin.X + square.Width, square.Begin.Y + square.Width);
                    }
                }
                else if (shape is Model.Rectangle rect)
                {
                    if (rect.Begin.X < rect.End.X && rect.Begin.Y > rect.End.Y)
                    {
                        Point begin = rect.Begin, end = rect.End;

                        rect.Begin = new Point(begin.X, end.Y);
                        rect.End = new Point(end.X, begin.Y);
                    }
                }

                if (currentShape != CurrentShape.NoDrawing)
                {
                    if (shape is Curve)
                    {
                        // Chỉ ghi khi đã vẽ xong đường cong đó
                        if (currentShape == CurrentShape.Curve && !isDrawCurve)
                        {
                            clbShape.Items.Add(shape.ToString());
                        }
                        else if (currentShape == CurrentShape.Bezier && !isDrawBezier)
                        {
                            clbShape.Items.Add(shape.ToString());
                        }
                    }
                    else if (shape is Polygon) // ngược lại nếu là đa giác
                    {
                        // thì cũng đợi vẽ xong mới ghi thông tin
                        if (!isDrawPolygon)
                        {
                            clbShape.Items.Add(shape.ToString());
                        }
                    }
                    else // ngược lại không là đường cong thì ghi bình thường
                    {
                        clbShape.Items.Add(shape.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnLine.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Line;
                btnLine.BackColor = Color.Silver;
            }
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnRectangle.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Rectangle;
                btnRectangle.BackColor = Color.Silver;
            }
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnEllipse.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Ellipse;
                btnEllipse.BackColor = Color.Silver;
            }
        }

        private void BtnSquare_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnSquare.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Square;
                btnSquare.BackColor = Color.Silver;
            }
        }

        private void BtnCircle_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnCircle.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Circle;
                btnCircle.BackColor = Color.Silver;
            }
        }

        private void BtnCurve_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnCurve.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Curve;
                btnCurve.BackColor = Color.Silver;
            }
        }

        private void BtnBezier_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnBezier.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Bezier;
                btnBezier.BackColor = Color.Silver;
            }
        }

        private void BtnPolygon_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            if (btnPolygon.BackColor == Color.Silver)
            {
                UncheckAll();
                currentShape = CurrentShape.NoDrawing;
                psfMain.Cursor = Cursors.Default;
                btnSelect.BackColor = Color.Silver;
            }
            else
            {
                UncheckAll();
                psfMain.Cursor = Cursors.Cross;
                currentShape = CurrentShape.Polygon;
                btnPolygon.BackColor = Color.Silver;
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            shapes.ForEach(shape => shape.IsSelected = false);
            psfMain.Invalidate();

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                clbShape.SetItemChecked(i, false);
            }

            currentShape = CurrentShape.NoDrawing;
            UncheckAll();
            btnSelect.BackColor = Color.Silver;
            psfMain.Cursor = Cursors.Default;
        }

        private void PsfMain_DoubleClick(object sender, EventArgs e)
        {
            if (isDrawPolygon)
            {
                isDrawPolygon = false;

                Polygon polygon = shapes[shapes.Count - 1] as Polygon;
                polygon.Points.RemoveAt(polygon.Points.Count - 1);

                psfMain.Invalidate();

                FindPolygonRegion(polygon);
            }
            else if (isDrawCurve)
            {
                isDrawCurve = false;

                Curve curve = shapes[shapes.Count - 1] as Curve;
                curve.Points.RemoveAt(curve.Points.Count - 1);
                curve.Points.RemoveAt(curve.Points.Count - 1);

                psfMain.Invalidate();

                FindCurveRegion(curve);
            }
        }

        private void ClbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            UncheckAll();
            EnableButtons();
            btnSelect.BackColor = Color.Silver;
            psfMain.Cursor = Cursors.Default;
            currentShape = CurrentShape.NoDrawing;
            trkLineWidth.Enabled = true;

            int index = clbShape.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            for (int i = 0; i < clbShape.Items.Count; i++)
            {
                shapes[i].IsSelected = clbShape.GetItemChecked(i);
            }
            psfMain.Invalidate();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            isControlKeyPress = e.Control;
            psfMain.Focus();

            if (e.Control)
            {
                movingOffset = 1;
            }
            else
            {
                movingOffset = 5;
            }

            if (e.KeyCode == Keys.Up)
            {
                MoveShape(ToUp);
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveShape(ToDown);
            }
            else if (e.KeyCode == Keys.Left)
            {
                MoveShape(ToLeft);
            }
            else if (e.KeyCode == Keys.Right)
            {
                MoveShape(ToRight);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            isControlKeyPress = e.Control;
        }

        private void BtnGroup_Click(object sender, EventArgs e)
        {
            if (shapes.Count(shape => shape.IsSelected) > 1)
            {
                Group group = new Group();

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].IsSelected)
                    {
                        group.Add(shapes[i]);
                        shapes.RemoveAt(i);
                        clbShape.Items.RemoveAt(i--);
                    }
                }

                FindGroupRegion(group);
                shapes.Add(group);
                clbShape.Items.Add(group);
                group.IsSelected = true;
                psfMain.Invalidate();
            }
        }

        private void BtnUngroup_Click(object sender, EventArgs e)
        {
            if (shapes.Find(shape => shape.IsSelected) is Group selectedGroup)
            {
                foreach (Shape shape in selectedGroup)
                {
                    shapes.Add(shape);
                    clbShape.Items.Add(shape.ToString());
                }
                shapes.Remove(selectedGroup);
                clbShape.Items.Clear();
                foreach (Shape shape in shapes)
                {
                    clbShape.Items.Add(shape.ToString());
                }
            }
            psfMain.Invalidate();
        }

        private void CmbShapeMode_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void CmbShapeMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void CmbShapeMode_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void TrkLineWidth_Scroll(object sender, EventArgs e)
        {
            if (trkLineWidth.Value == 0)
            {
                lblWidth.Text = "Default";
            }
            else
            {
                lblWidth.Text = trkLineWidth.Value.ToString();
            }

            shapes.FindAll(shape => shape.IsSelected).ForEach(shape =>
            {
                if (shape is Group group)
                {
                    foreach (Shape s in group)
                    {
                        s.LineWidth = trkLineWidth.Value;
                    }
                }
                else
                {
                    shape.LineWidth = trkLineWidth.Value;
                }
            });
            psfMain.Invalidate();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bool isFillMode = cmbShapeMode.SelectedIndex == 1; 
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].IsSelected)
                {
                    shapes.RemoveAt(i);
                    clbShape.Items.RemoveAt(i--);
                }
            }
            psfMain.Invalidate();
            if (isFillMode)
            {
                cmbShapeMode.SelectedIndex = 1;
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = color.Color;
            }
            shapes.FindAll(shape => shape.IsSelected).ForEach(shape =>
            {
                if (shape is Group group)
                {
                    foreach (Shape s in group)
                    {
                        s.Color = btnColor.BackColor;
                    }
                }
                else
                {
                    shape.Color = btnColor.BackColor;
                }
            });
            psfMain.Invalidate();
        }

        private void CmbShapeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
            if (cmbShapeMode.SelectedIndex == 0)
            {
                mode = ShapeMode.NoFill;
                EnableButtons();
                trkLineWidth.Enabled = true;
                cmbDashMode.Enabled = true;
            }
            else if (cmbShapeMode.SelectedIndex == 1)
            {
                mode = ShapeMode.Fill;
                trkLineWidth.Enabled = false;
                btnLine.Enabled = btnCurve.Enabled = btnBezier.Enabled = false;
                cmbDashMode.Enabled = false;
            }
        }

        private void CmbDashMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            shapes.FindAll(shape => shape.IsSelected).ForEach(shape =>
            {
                shape.DashStyle = (DashStyle)cmbDashMode.SelectedIndex;
            });
            psfMain.Invalidate();
        }
        #endregion
    }
}