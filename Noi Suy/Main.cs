using Microsoft.Office.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace NoiSuy
{
    public partial class frmMain : Form
    {
        ContextMenuStrip contextMenu1;
        ContextMenuStrip contextMenu2;
        ToolStripMenuItem tool1;
        ToolStripMenuItem tool2;
        ToolStripMenuItem toolNone;
        ToolStripMenuItem tool4;
        ToolStripItem[] t4Items;
        public string tenFile { get; set; }
        int row = 0;
        int countClick = 1;
        int number = 1;//Số lần lưu file mới
        public frmMain()
        {

            Thread th = new Thread(new ThreadStart(SplashScren));
            th.Start();
            Thread.Sleep(3000);

            InitializeComponent();

            this.KeyPreview = true;
            th.Abort();
            rbt2chieu.Select();


            contextMenu1 = new ContextMenuStrip();
            tool1 = new ToolStripMenuItem();
            tool1.Text = "Tính+Thêm";
            tool1.Click += new System.EventHandler(this.ChiThem_Click);
            contextMenu1.Items.Add(tool1);
            btnThem.ContextMenuStrip = contextMenu1;

            contextMenu2 = new ContextMenuStrip();
            tool2 = new ToolStripMenuItem();
            tool2.Text = "Change Image";
            try
            {
                tool2.Image = Image.FromFile(Properties.Settings.Default.urlPic);
            }
            catch
            {
                tool2.Image = default;
            }
            tool2.Click += new System.EventHandler(this.ChangPicture_Click);

            toolNone = new ToolStripMenuItem();
            toolNone.Text = "Set None";

            // toolNone.Image = Image.FromFile("../../Ad-Aware-icon.png");
            toolNone.Click += new System.EventHandler(this.NonePicture_Click);

            tool4 = new ToolStripMenuItem();
            tool4.Text = "Change Mode Image";
            try
            {
                tool4.Image = Image.FromFile(Properties.Settings.Default.urlPic);
            }
            catch
            {

                tool4.Image = default;
            }
            ToolStripMenuItem t4Normal = new ToolStripMenuItem();
            t4Normal.Text = "Nomal Image";

            t4Normal.Click += new System.EventHandler(this.ImageMode_Click);
            ToolStripMenuItem t4Stretch = new ToolStripMenuItem();
            t4Stretch.Text = "Fit Image";

            t4Stretch.Click += new System.EventHandler(this.ImageMode_Click);
            ToolStripMenuItem t4AutoSize = new ToolStripMenuItem();
            t4AutoSize.Text = "AutoSize Image";
            t4AutoSize.Click += new System.EventHandler(this.ImageMode_Click);
            ToolStripMenuItem t4Center = new ToolStripMenuItem();
            t4Center.Text = "Center Image";
            t4Center.Click += new System.EventHandler(this.ImageMode_Click);
            ToolStripMenuItem t4SZoom = new ToolStripMenuItem();
            t4SZoom.Text = "Zoom Image";
            t4SZoom.Click += new System.EventHandler(this.ImageMode_Click);
            t4Items = new ToolStripItem[] { t4Stretch, t4AutoSize, t4Center, t4SZoom, t4Normal };

            tool4.DropDownItems.AddRange(t4Items);

            contextMenu2.Items.AddRange(new ToolStripItem[] { tool2, tool4, toolNone });

            pictureBox1.ContextMenuStrip = contextMenu2;


        }



        public void SplashScren()
        {
            Application.Run(new frmFlashScreen());
        }

        private void AddImage(Image url)
        {
            foreach (var item in t4Items)
            {
                item.Image = url;
            }
        }

        private void ImageMode_Click(object sender, EventArgs e)
        {
            string nameofToolItem = (sender as ToolStripItem).Text;

            switch (nameofToolItem)
            {
                case "Normal Image":
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                        break;
                    }
                case "Fit Image":
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    }
                case "AutoSize Image":
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;
                    }
                case "Center Image":
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                        break;
                    }
                case "Zomm Image":
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        break;

                    }
                default:
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                        break;
                    }



            }


        }
        private void NonePicture_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void ChangPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPic = new OpenFileDialog();
            openPic.Filter = "All file|*png;*jpg;*bmp";
            openPic.Multiselect = true;

            if (openPic.ShowDialog() == DialogResult.OK)
            {
                int picSelect = openPic.FileNames.Length;

                if (picSelect == 1)
                {
                    pictureBox1.Image = Image.FromFile(openPic.FileName);
                }

                else
                {


                    // System.Timers.Timer t2 = new System.Timers.Timer();
                    //  t2.Interval = 5000;

                    string[] urlPic = openPic.FileNames;

                    //foreach (var item in urlPic)
                    // {

                    // pictureBox1.Image = Image.FromFile(item);
                    for (int i = 0; i < picSelect; i++)
                    {

                        // t2.Stop();
                        pictureBox1.Image = Image.FromFile(urlPic[i]);
                        pictureBox1.Update();

                        // t2.Start();
                    }

                    // }

                }


            }

            NoiSuy.Properties.Settings.Default.urlPic = openPic.FileName;
            NoiSuy.Properties.Settings.Default.Save();

        }



        private void ChiThem_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Test");


            btnThem.Text = ChiThem();
            tool1.Text = ChiThem();
        }
        private string ChiThem()
        {
            string txt;
            if (btnThem.Text == "Thêm >>")
            {
                txt = "Tính+Thêm";
                // btnThem.TextAlign = ContentAlignment.MiddleLeft;
                // btnThem.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                txt = "Thêm >>";
                // btnThem.TextAlign = ContentAlignment.MiddleCenter;
            }
            return txt;
        }
        private void chon()
        {
            if (rbt1chieu.Checked == true)
            {
                grp.Text = rbt1chieu.Text;
                txty.Visible = false;
                txty1.Visible = false;
                txty2.Visible = false;
                txtx1y2.Visible = false;
                txtx2y2.Visible = false;
                labY2.Visible = false;
                labY.Text = "KQ";
                btnVertical.Visible = false;
            }
            else
            {
                grp.Text = rbt2chieu.Text;
                txty.Visible = true;
                txty1.Visible = true;
                txty2.Visible = true;
                txtx1y2.Visible = true;
                txtx2y2.Visible = true;
                labY2.Visible = true;
                labY.Text = "Y";
                btnVertical.Visible = true;
                //txtxy1.Visible = true;
                //txtxy2.Visible = true;
                // txty.Visible = false;
            }
        }
        private int rowSelect()
        {
            return dgvKQ.CurrentCell.RowIndex;

        }
        private double Tinh()
        {
            double x, y, x1, y1, x2, y2, x1y1, x1y2, x2y1, x2y2;
            double.TryParse(txtx.Text, out x);
            double.TryParse(txtx1.Text, out x1);
            double.TryParse(txtx2.Text, out x2);
            double.TryParse(txty.Text, out y);
            double.TryParse(txty1.Text, out y1);
            double.TryParse(txty2.Text, out y2);
            double.TryParse(txtx1y1.Text, out x1y1);
            double.TryParse(txtx1y2.Text, out x1y2);
            double.TryParse(txtx2y1.Text, out x2y1);
            double.TryParse(txtx2y2.Text, out x2y2);
            double vl1, vl2;
            if (rbt1chieu.Checked == true)
            {
                return (x2y1 * (x - x1) + x1y1 * (x2 - x)) / (x2 - x1);
            }
            else
            {
                vl1 = (x2y1 * (x - x1) + x1y1 * (x2 - x)) / (x2 - x1);
                vl2 = (x2y2 * (x - x1) + x1y2 * (x2 - x)) / (x2 - x1);
                return (vl2 * (y - y1) + vl1 * (y2 - y)) / (y2 - y1);
            }
        }
        private void Thems()
        {
            if (this.BackColor == Color.Black)
            {
                labX.ForeColor = labX1.ForeColor = labX2.ForeColor = labY.ForeColor =
                    labY1.ForeColor = labY2.ForeColor = rbt1chieu.ForeColor = rbt2chieu.ForeColor =
                     groupBox1.ForeColor = grp.ForeColor = Color.White;
                fileToolStripMenuItem.ForeColor = Color.OrangeRed;
                btnClear.ForeColor = dgvKQ.ForeColor = Color.Black;
            }
            else
            {
                labX.ForeColor = labX1.ForeColor = labX2.ForeColor = labY.ForeColor =
                    labY1.ForeColor = labY2.ForeColor = rbt1chieu.ForeColor =
                    rbt2chieu.ForeColor = groupBox1.ForeColor = grp.ForeColor = fileToolStripMenuItem.ForeColor = Color.Black;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.FormSize;
            this.Location = Properties.Settings.Default.Location;
            this.changFormSizeToolStripMenuItem.Text = this.Size != new Size() ? "Thu Nhỏ" : "Mở Rộng";//chưa làm được
            this.BackColor = dgvKQ.BackgroundColor = menuStrip.BackColor = fileToolStripMenuItem.BackColor = Properties.Settings.Default.color;
            Thems();
            labAuthor.Text = Properties.Settings.Default.Name;
            labAuthor.ForeColor = Color.White;
            try
            {
                pictureBox1.Image = Image.FromFile(NoiSuy.Properties.Settings.Default.urlPic);
            }
            catch
            {
                pictureBox1.Image = default;
            }

            //labAuthor.BackColor = Color.;
            // timer1.Enabled = true;
            if (Properties.Settings.Default.stop == true)
            {
                timer1.Stop();

            }
            else { timer1.Start(); }
            ColorTitle();
        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            txtxy.Text = Tinh().ToString();
        }
        private void Them()
        {
            row = dgvKQ.RowCount - 1;
            dgvKQ.Rows.Add(1);
            char c = rbt1chieu.Checked == true ? '1' : '2';
            dgvKQ.Rows[row].Cells["stt"].Value = countClick++ + "_" + c;
            if (rbt1chieu.Checked == true)
            {
                dgvKQ.Rows[row].Cells["x"].Value = txtx.Text;
                dgvKQ.Rows[row].Cells["x1"].Value = txtx1.Text;
                dgvKQ.Rows[row].Cells["x2"].Value = txtx2.Text;
                dgvKQ.Rows[row].Cells["x1y1"].Value = txtx1y1.Text;
                dgvKQ.Rows[row].Cells["x2y1"].Value = txtx2y1.Text;
                dgvKQ.Rows[row].Cells["kq"].Value = txtxy.Text;
            }
            else
            {
                dgvKQ.Rows[row].Cells["x"].Value = txtx.Text;
                dgvKQ.Rows[row].Cells["x1"].Value = txtx1.Text;
                dgvKQ.Rows[row].Cells["x2"].Value = txtx2.Text;
                dgvKQ.Rows[row].Cells["y"].Value = txty.Text;
                dgvKQ.Rows[row].Cells["y1"].Value = txty1.Text;
                dgvKQ.Rows[row].Cells["y2"].Value = txty2.Text;
                dgvKQ.Rows[row].Cells["x1y1"].Value = txtx1y1.Text;
                dgvKQ.Rows[row].Cells["x1y2"].Value = txtx1y2.Text;
                dgvKQ.Rows[row].Cells["x2y1"].Value = txtx2y1.Text;
                dgvKQ.Rows[row].Cells["x2y2"].Value = txtx2y2.Text;
                dgvKQ.Rows[row].Cells["kq"].Value = txtxy.Text;
            }
            return;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm >>")
            {
                Them();
            }
            else
            {
                btnTinh_Click(sender, e);
                Them();

            }
            // dgvKQ.Rows[row].HeaderCell. = row.ToString();
        }


        private void rbt1chieu_CheckedChanged(object sender, EventArgs e)
        {
            chon();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvKQ.SelectedRows)
                {
                    dgvKQ.Rows.Remove(row);
                }
            }

            catch { }

        }
        private void dgvKQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvKQ.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                int l = dgvKQ.Rows[rowSelect()].Cells["stt"].Value.ToString().Length;
                //ns1chieu;
                if (dgvKQ.Rows[rowSelect()].Cells["stt"].Value.ToString().Substring(l - 1, 1) == "1")//lay ky tu cuoi
                {
                    rbt1chieu.Checked = true;
                    txtx.Text = dgvKQ.Rows[rowSelect()].Cells["x"].Value.ToString();
                    txtx1.Text = dgvKQ.Rows[rowSelect()].Cells["x1"].Value.ToString();
                    txtx2.Text = dgvKQ.Rows[rowSelect()].Cells["x2"].Value.ToString();
                    txtx1y1.Text = dgvKQ.Rows[rowSelect()].Cells["x1y1"].Value.ToString();
                    txtx2y1.Text = dgvKQ.Rows[rowSelect()].Cells["x2y1"].Value.ToString();
                    txty1.Text = dgvKQ.Rows[rowSelect()].Cells["x2y1"].Value.ToString();

                    txtxy.Text = dgvKQ.Rows[rowSelect()].Cells["kq"].Value.ToString();
                }
                else//ns2 chieu
                {
                    rbt2chieu.Select();
                    txtx.Text = dgvKQ.Rows[rowSelect()].Cells["x"].Value.ToString();
                    txtx1.Text = dgvKQ.Rows[rowSelect()].Cells["x1"].Value.ToString();
                    txtx2.Text = dgvKQ.Rows[rowSelect()].Cells["x2"].Value.ToString();
                    txty.Text = dgvKQ.Rows[rowSelect()].Cells["y"].Value.ToString();
                    txty1.Text = dgvKQ.Rows[rowSelect()].Cells["y1"].Value.ToString();
                    txty2.Text = dgvKQ.Rows[rowSelect()].Cells["y2"].Value.ToString();
                    txtx1y1.Text = dgvKQ.Rows[rowSelect()].Cells["x1y1"].Value.ToString();
                    txtx1y2.Text = dgvKQ.Rows[rowSelect()].Cells["x1y2"].Value.ToString();
                    txtx2y1.Text = dgvKQ.Rows[rowSelect()].Cells["x2y1"].Value.ToString();
                    txtx2y2.Text = dgvKQ.Rows[rowSelect()].Cells["x2y2"].Value.ToString();

                    txtxy.Text = dgvKQ.Rows[rowSelect()].Cells["kq"].Value.ToString();
                }
            }
            catch { }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                char c = rbt1chieu.Checked == true ? '1' : '2';
                int l = dgvKQ.Rows[rowSelect()].Cells["stt"].Value.ToString().Length;
                dgvKQ.Rows[rowSelect()].Cells["stt"].Value = dgvKQ.Rows[rowSelect()].Cells["stt"].Value.ToString().Substring(0, l - 1) + c;
                if (rbt1chieu.Checked == true)
                {
                    dgvKQ.Rows[rowSelect()].Cells["x"].Value = txtx.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x1"].Value = txtx1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x2"].Value = txtx2.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x1y1"].Value = txtx1y1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x2y1"].Value = txtx2y1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["kq"].Value = txtxy.Text;
                }
                else
                {
                    dgvKQ.Rows[rowSelect()].Cells["x"].Value = txtx.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x1"].Value = txtx1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x2"].Value = txtx2.Text;
                    dgvKQ.Rows[rowSelect()].Cells["y"].Value = txty.Text;
                    dgvKQ.Rows[rowSelect()].Cells["y1"].Value = txty1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["y2"].Value = txty2.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x1y1"].Value = txtx1y1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x1y2"].Value = txtx1y2.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x2y1"].Value = txtx2y1.Text;
                    dgvKQ.Rows[rowSelect()].Cells["x2y2"].Value = txtx2y2.Text;
                    dgvKQ.Rows[rowSelect()].Cells["kq"].Value = txtxy.Text;

                }

            }
            catch { };
        }
        int jump = 1;
        byte n = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            int l = labAuthor.Width;
            int w = splitContainer1.Panel1.Width;
            int px = labAuthor.Location.X;
            int py = labAuthor.Location.Y;
            labAuthor.Location = new Point(px + jump, py);//move to right +=3
            if (px < -l)
            {
                jump = 1;
            }

            if (px > w)
            {
                //labAuthor.Location = new Point(0 - l, py);//setlai
                jump = -1;
            }
            //Doi mau chu

            n = n >= 255 ? (byte)0 : n;
            n++;
            labAuthor.ForeColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0))) + n));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu và thoát chương trình không ?", "Thông báo:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    {

                        saveToolStripMenuItem_Click(sender, e);

                        break;
                    }
                case DialogResult.No:
                    {
                        //this.Dispose();

                        break;
                    }
                case DialogResult.Cancel:
                    {
                        e.Cancel = true;
                        break;
                    }


            }
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.FormSize = this.Size;
            Properties.Settings.Default.Save();

        }
        private void dgvKQ_KeyDown(object sender, KeyEventArgs e)
        {
            //int sumrow = dgvKQ.RowCount -1;
            //int rowIndex = dgvKQ.SelectedCells[0].OwningRow.Index;
            //DataGridView dgv = dgvKQ;
            //switch (Keys.KeyCode)
            //{
            //    case Keys.Down:
            //        {
            //            if (rowIndex == sumrow)
            //                return;
            //            int colIndex = dgvKQ.SelectedCells[0].OwningColumn.Index;
            //            DataGridView SELECTEDrOW = dgv.Rows[rowIndex];
            //            break;
            //        }
            //}
            //MessageBox.Show(sumrow.ToString());
        }
        void luuFile(string tenFile)
        {
            FileStream file = new FileStream(tenFile, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file, Encoding.UTF8);

            int row = dgvKQ.RowCount - 1;

            for (int i = 0; i <= row; i++)
            {
                writer.WriteLine(dgvKQ.Rows[i].Cells["stt"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["y"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["kq"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x1"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x2"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["y1"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["y2"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x1y1"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x1y2"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x2y1"].Value);
                writer.WriteLine(dgvKQ.Rows[i].Cells["x2y2"].Value);
            }
            file.Flush();
            writer.Close();
            file = null;
            writer = null;

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
        private void saveFile()
        {
            bool existFile = File.Exists(tenFile);
            if (existFile == true)//save.ShowDialog() == DialogResult.OK
            {
                luuFile(tenFile);
                MessageBox.Show("Save Done !", "Information", MessageBoxButtons.OK);
            }
            else//save as
            {
                saveAsFile();
            }
            this.Text = "PHẦN MỀM TÍNH NỘI SUY Pro - [" + tenFile + "]";
        }
        private void saveAsFile()
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All file (NoiSuy)|*.txt";
            save.Title = "Save As Text File - [Nội Suy]";
            save.FileName = "NoiSuy" + number.ToString() + ".txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                luuFile(save.FileName);
                //Cap nhat ten file
                tenFile = save.FileName;
                MessageBox.Show("Save as Done !", "Information", MessageBoxButtons.OK);
            }
            else
            {
               
            }



            save.Dispose();
            save = null;
            number++;


        }

        


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "All file (NoiSuy)|*.txt";
                open.Title = "Open Text File - [Nội Suy]";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    tenFile = open.FileName;
                    FileStream stream = new FileStream(open.FileName, FileMode.Open, FileAccess.ReadWrite);
                    StreamReader reader = new StreamReader(stream, true);
                    //Dem so dong file txt
                    //int  countRow = reader.ReadLine().Length-1;
                    // int countRow = File.ReadAllLines(open.FileName, Encoding.UTF8).Length;
                    int c = 0, countRow = 0;
                    while (reader.ReadLine() != null)
                    {
                        countRow++;
                    }
                    //Set Positon =0;
                    stream.Position = 0;
                    dgvKQ.Rows.Clear();
                    int dong = countRow / 12 - 1;
                    dgvKQ.Rows.Add(dong);
                    //Doc file 
                    for (int i = 0; i < dong; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            dgvKQ[j, i].Value = reader.ReadLine();
                        }
                    }
                    reader.Close();
                    stream.Close();
                    open.Dispose();
                    countClick = 1;
                    stream = null;
                    reader = null;

                }
                open = null;

            }
            catch
            {
                //tenFile = null;
            }
            finally
            {
                this.Text = "PHẦN MỀM TÍNH NỘI SUY Pro - [" + tenFile + "]";
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvKQ.Rows.Clear();

            txtx.ResetText();
            txtx1.ResetText();
            txtx2.ResetText();
            txty.ResetText();
            txty1.ResetText();
            txty2.ResetText();
            txtx1y1.ResetText();
            txtx1y2.ResetText();
            txtx2y1.ResetText();
            txtx2y2.ResetText();
            txtxy.ResetText();
            tenFile = null;


            row = 0;
            countClick = 1;
            this.Text = "PHẦN MỀM TÍNH NỘI SUY Pro";
            GC.Collect();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f2 = new Form();
            f2.Width = 500;
            f2.Height = 300;
            f2.ShowIcon = false;
            f2.AutoSize = false;
            f2.Text = "About Nội Suy Pro";
            f2.AutoSize = false;
            f2.BackColor = Color.Black;
            f2.MaximizeBox = false;
            f2.MinimizeBox = false;
            f2.FormBorderStyle = FormBorderStyle.FixedSingle;
            Label lab1 = new Label();
            f2.Controls.Add(lab1);
            lab1.Location = new Point(30, 0);
            lab1.Width = 450;
            lab1.Height = 300;
            lab1.Font = new Font("Times new roman", 12);
            lab1.ForeColor = Color.ForestGreen;
            //lab1.BackColor = Color.White;
            string txt = "Năm phát hành : 2019\nThis product designed by : Nguyễn Văn Mậu - 2014x7- HAU\nNgôn ngữ lập trình : C# (C Sharp)\n";
            int count = 12;
            //char[] c = txt.ToCharArray();
            int i = 0;
            while (i <= count)
            {
                lab1.Text += txt + "\n";
                i++;
            }
            f2.Show(this);
        }
        private void ExportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set region = US
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet ws = null;
            ws = (Excel.Worksheet)wb.Worksheets["Sheet1"];
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Export to Excel";
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx;*.xls";
                //saveDialog.FilterIndex = 2;

                saveDialog.FileName = "Book" + number.ToString();

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ws.Name = "Ket Qua Noi Suy";
                    Excel.Range r = ws.Range["A1:L1"];
                    r.Merge();
                    r.Value = "Bảng tính nội suy";
                    r.BorderAround2();
                    r.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //r.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    // r.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    // r.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    // r.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;

                    int i = 0, j = 0;
                    while (i < dgvKQ.ColumnCount)
                    {
                        //tieu de cot
                        ws.Cells[2, i + 1] = dgvKQ.Columns[i].HeaderText;
                        for (j = 0; j < dgvKQ.RowCount; j++)
                        {
                            ws.Cells[j + 3, i + 1] = dgvKQ[i, j].Value;
                            ws.Range[ws.Cells[j + 2, i + 1], ws.Cells[j + 2, i + 1]].BorderAround2();
                        }
                        i++;
                    }
                    wb.SaveAs(saveDialog.FileName);
                    app.Quit();
                    MessageBox.Show("Export Successful");
                }
                //Open Folder
                Process folderProcess = new Process();
                folderProcess.StartInfo.UseShellExecute = true;
            
                folderProcess.StartInfo.FileName = Path.GetDirectoryName(saveDialog.FileName);
                // folderProcess.StartInfo.Arguments = "/select";
                folderProcess.Start();
               
                // Process.Start("explorer", "/select," + saveDialog.FileName);
                saveDialog = null;
                folderProcess = null;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Không thể mở được Folder do không thấy đường dẫn");
            }

            app = null;
            wb = null;
            ws = null;


        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFile();
            this.Text = "PHẦN MỀM TÍNH NỘI SUY Pro - [" + tenFile + "]";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtx.ResetText();
            txtx1.ResetText();
            txtx2.ResetText();
            txty.ResetText();
            txty1.ResetText();
            txty2.ResetText();
            txtx1y1.ResetText();
            txtx1y2.ResetText();
            txtx2y1.ResetText();
            txtx2y2.ResetText();
            txtxy.ResetText();
        }

        private void btnVertical_Click(object sender, EventArgs e)
        {
            string y = txty1.Text;
            txty1.Text = txty2.Text;
            txty2.Text = y;
            string x1y = txtx1y1.Text;
            txtx1y1.Text = txtx1y2.Text;
            txtx1y2.Text = x1y;
            string x2y = txtx2y1.Text;
            txtx2y1.Text = txtx2y2.Text;
            txtx2y2.Text = x2y;
        }

        private void btnHorizon_Click(object sender, EventArgs e)
        {
            if (rbt1chieu.Checked == true)
            {
                string x = txtx1.Text;
                txtx1.Text = txtx2.Text;
                txtx2.Text = x;
                string y1 = txtx1y1.Text;
                txtx1y1.Text = txtx2y1.Text;
                txtx2y1.Text = y1;

            }
            else
            {
                string x = txtx1.Text;
                txtx1.Text = txtx2.Text;
                txtx2.Text = x;
                string y1 = txtx1y1.Text;
                txtx1y1.Text = txtx2y1.Text;
                txtx2y1.Text = y1;
                string y2 = txtx1y2.Text;
                txtx1y2.Text = txtx2y2.Text;
                txtx2y2.Text = y2;
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.SplitterDistance = 520;
                pictureBox1.Width = splitContainer1.SplitterDistance;
                pictureBox1.Height = this.Height - grp.Height - 90;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            catch { }

        }

        private void MenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //labAuthor.Text = "123";
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (stopToolStripMenuItem.Text == "Stop")
            {
                timer1.Stop();
                Properties.Settings.Default.stop = true;
                stopToolStripMenuItem.Text = "Continue";
            }
            else
            {

                timer1.Enabled = true;
                Properties.Settings.Default.stop = false;
                stopToolStripMenuItem.Text = "Stop";
            }



        }
        Form frmYourName;
        Label labName;
        TextBox txtName;
        Button btnOk;
        Button btnCancel;
        //Form frmYourName = new Form();
        //Label labName = new Label();
        //TextBox txtName = new TextBox();
        //Button btnOk = new Button();
        //Button btnCancel = new Button();
        private void AddYourNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYourName = new Form();
            labName = new Label();
            txtName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();

            frmYourName.Size = new Size(500, 200);
            //frmYourName.MaximizeBox = false;
            frmYourName.ShowIcon = false;
            frmYourName.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frmYourName.KeyPreview = true;
            frmYourName.BackColor = this.BackColor;
            frmYourName.Font = new Font("arial", 11);

            labName.AutoSize = true;
            labName.Text = "Nhập nội dung:";
            labName.Font = new Font("Times new romam", 12);

            txtName.Size = new Size(320, 150);
            txtName.Font = new Font("Times new romam", 11);
            txtName.Anchor = AnchorStyles.Top;
            txtName.Anchor = AnchorStyles.Right;
            txtName.Anchor = AnchorStyles.Left; ;
            txtName.Text = Properties.Settings.Default.Name;
            txtName.Location = new Point(labName.Location.X + labName.Width + 20, labName.Location.Y);
            txtName.Focus();
            btnOk.Text = "OK";
            btnOk.Size = new Size(120, 50);
            btnOk.Location = new Point(txtName.Location.X, txtName.Location.Y + txtName.Height + 20);


            btnCancel.Text = "Cancel";
            btnCancel.Size = btnOk.Size;
            btnCancel.Location = new Point(btnOk.Location.X + btnOk.Width + 20, txtName.Location.Y + txtName.Height + 20);

            labName.BackColor = btnCancel.BackColor = btnOk.BackColor = Color.Gray;

            frmYourName.Controls.AddRange(new Control[] { labName, txtName, btnOk, btnCancel });
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += Cancel_Click;
            frmYourName.KeyDown += FrmYourName_KeyDown;

            //Event
            frmYourName.ShowDialog();
        }

        private void FrmYourName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                BtnOk_Click(sender, e);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {//check  txtName.Text is blank
            txtName.Text = txtName.Text == "" ? "   " : txtName.Text;
            labAuthor.Text = txtName.Text;

            Properties.Settings.Default.Name = txtName.Text;
            Properties.Settings.Default.Save();

            frmYourName.Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            frmYourName.Dispose();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyData == (Keys.Control | Keys.O))
            {
                openToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyData == (Keys.Control | Keys.N))
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyData == (Keys.Control | Keys.E))
            {
                ExportToExcelToolStripMenuItem_Click(sender, e);
            }

            else if (e.KeyData == (Keys.Alt | Keys.F4))
            {
                Application.Exit();

            }
            // Select file
            else if (e.KeyData == (Keys.Control | Keys.F))
            {
                fileToolStripMenuItem.ShowDropDown();
            }
            else
            {

            }

        }
        private void ColorThemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = color.Color;
                dgvKQ.BackgroundColor = color.Color;
                menuStrip.BackColor = color.Color;
                fileToolStripMenuItem.BackColor = color.Color;
                Properties.Settings.Default.color = color.Color;
                Thems();
            }
            color = null;
        }

        private void ColorTitle()
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillRectangle(b, new Rectangle(0, 0, 200, 100));

            g.Flush();


        }





        private void AddContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddYourNameToolStripMenuItem_Click(sender, e);
        }
        private void AddContentsToolStripPic_Click(object sender, EventArgs e)
        {
            AddYourNameToolStripMenuItem_Click(sender, e);
        }




        private void PictureBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            try
            {
                AddImage(Image.FromFile(Properties.Settings.Default.urlPic));
            }
            catch { }

        }

        private void SplitContainer1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = splitContainer1.Width;
        }

        private void SplitContainer1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = splitContainer1.Width;
        }

        private void SplitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = splitContainer1.Width;
        }


        bool expand = false;
        int width;
        int height;

        private void PictureBox2_Click(object sender, EventArgs e)
        {




            if (expand)
            {
                this.Size = new Size(width, height);

                this.FormBorderStyle = FormBorderStyle.Sizable;
                pictureBoxSize.BackColor = Color.Green;
                toolTipPictureBoxSize.SetToolTip(pictureBoxSize, "Thu Nhỏ");
                changFormSizeToolStripMenuItem.Text = "Thu Nhỏ";
                expand = false;
            }
            //unexpand- thu nho
            else
            {
                //Save SizeForm 
                width = this.Size.Width;
                height = this.Size.Height;
                //Action
                this.AutoSize = false;
                pictureBoxSize.BackColor = Color.LightGreen;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                toolTipPictureBoxSize.SetToolTip(pictureBoxSize, "Mở Rộng");
                changFormSizeToolStripMenuItem.Text = "Mở Rộng";
                this.Width = grp.Location.X + grp.Width + 8;
                this.Height = grp.Location.Y + grp.Height + 70;
                this.WindowState = FormWindowState.Normal;
                expand = true;
            }
        }
    }
}
