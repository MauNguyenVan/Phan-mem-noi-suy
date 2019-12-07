using System.Drawing;
namespace Noi_Suy
{ 
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labAuthor = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addYourNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grp = new System.Windows.Forms.GroupBox();
            this.pictureBoxSize = new System.Windows.Forms.PictureBox();
            this.txtx2y2 = new System.Windows.Forms.TextBox();
            this.rbt2chieu = new System.Windows.Forms.RadioButton();
            this.rbt1chieu = new System.Windows.Forms.RadioButton();
            this.txty2 = new System.Windows.Forms.TextBox();
            this.txtx1y2 = new System.Windows.Forms.TextBox();
            this.txtxy = new System.Windows.Forms.TextBox();
            this.txtx2 = new System.Windows.Forms.TextBox();
            this.txtx2y1 = new System.Windows.Forms.TextBox();
            this.txty = new System.Windows.Forms.TextBox();
            this.txtx = new System.Windows.Forms.TextBox();
            this.txty1 = new System.Windows.Forms.TextBox();
            this.txtx1 = new System.Windows.Forms.TextBox();
            this.txtx1y1 = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnVertical = new System.Windows.Forms.Button();
            this.btnHorizon = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTinh = new System.Windows.Forms.Button();
            this.labY2 = new System.Windows.Forms.Label();
            this.labY = new System.Windows.Forms.Label();
            this.labX2 = new System.Windows.Forms.Label();
            this.labX = new System.Windows.Forms.Label();
            this.labX1 = new System.Windows.Forms.Label();
            this.labY1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKQ = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorThemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changFormSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipPictureBoxSize = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.labAuthor);
            this.splitContainer1.Panel1.Controls.Add(this.grp);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1.SizeChanged += new System.EventHandler(this.SplitContainer1_Panel1_SizeChanged);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1057, 567);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 317);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.PictureBox1_ChangeUICues);
            // 
            // labAuthor
            // 
            this.labAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labAuthor.AutoSize = true;
            this.labAuthor.ContextMenuStrip = this.contextMenuStrip;
            this.labAuthor.Location = new System.Drawing.Point(0, 548);
            this.labAuthor.Name = "labAuthor";
            this.labAuthor.Size = new System.Drawing.Size(57, 20);
            this.labAuthor.TabIndex = 5;
            this.labAuthor.Text = "Author";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopToolStripMenuItem,
            this.addYourNameToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowCheckMargin = true;
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(148, 48);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // addYourNameToolStripMenuItem
            // 
            this.addYourNameToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addYourNameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addYourNameToolStripMenuItem.Image")));
            this.addYourNameToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addYourNameToolStripMenuItem.Name = "addYourNameToolStripMenuItem";
            this.addYourNameToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addYourNameToolStripMenuItem.Text = "Add Contents";
            this.addYourNameToolStripMenuItem.Click += new System.EventHandler(this.AddYourNameToolStripMenuItem_Click);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.pictureBoxSize);
            this.grp.Controls.Add(this.txtx2y2);
            this.grp.Controls.Add(this.rbt2chieu);
            this.grp.Controls.Add(this.rbt1chieu);
            this.grp.Controls.Add(this.txty2);
            this.grp.Controls.Add(this.txtx1y2);
            this.grp.Controls.Add(this.txtxy);
            this.grp.Controls.Add(this.txtx2);
            this.grp.Controls.Add(this.txtx2y1);
            this.grp.Controls.Add(this.txty);
            this.grp.Controls.Add(this.txtx);
            this.grp.Controls.Add(this.txty1);
            this.grp.Controls.Add(this.txtx1);
            this.grp.Controls.Add(this.txtx1y1);
            this.grp.Controls.Add(this.btnXoa);
            this.grp.Controls.Add(this.btnThem);
            this.grp.Controls.Add(this.btnSua);
            this.grp.Controls.Add(this.btnVertical);
            this.grp.Controls.Add(this.btnHorizon);
            this.grp.Controls.Add(this.btnClear);
            this.grp.Controls.Add(this.btnTinh);
            this.grp.Controls.Add(this.labY2);
            this.grp.Controls.Add(this.labY);
            this.grp.Controls.Add(this.labX2);
            this.grp.Controls.Add(this.labX);
            this.grp.Controls.Add(this.labX1);
            this.grp.Controls.Add(this.labY1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Margin = new System.Windows.Forms.Padding(4);
            this.grp.Name = "grp";
            this.grp.Padding = new System.Windows.Forms.Padding(4);
            this.grp.Size = new System.Drawing.Size(520, 318);
            this.grp.TabIndex = 4;
            this.grp.TabStop = false;
            this.grp.Text = "groupBox2";
            // 
            // pictureBoxSize
            // 
            this.pictureBoxSize.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBoxSize.Location = new System.Drawing.Point(499, 296);
            this.pictureBoxSize.Name = "pictureBoxSize";
            this.pictureBoxSize.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSize.TabIndex = 21;
            this.pictureBoxSize.TabStop = false;
            this.toolTipPictureBoxSize.SetToolTip(this.pictureBoxSize, "Thu Nhỏ");
            this.pictureBoxSize.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // txtx2y2
            // 
            this.txtx2y2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtx2y2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx2y2.Location = new System.Drawing.Point(404, 210);
            this.txtx2y2.Margin = new System.Windows.Forms.Padding(4);
            this.txtx2y2.Name = "txtx2y2";
            this.txtx2y2.Size = new System.Drawing.Size(96, 26);
            this.txtx2y2.TabIndex = 9;
            // 
            // rbt2chieu
            // 
            this.rbt2chieu.AutoSize = true;
            this.rbt2chieu.BackColor = System.Drawing.Color.Purple;
            this.rbt2chieu.Checked = true;
            this.rbt2chieu.Location = new System.Drawing.Point(19, 66);
            this.rbt2chieu.Margin = new System.Windows.Forms.Padding(4);
            this.rbt2chieu.Name = "rbt2chieu";
            this.rbt2chieu.Size = new System.Drawing.Size(133, 24);
            this.rbt2chieu.TabIndex = 15;
            this.rbt2chieu.TabStop = true;
            this.rbt2chieu.Text = "Nội suy 2 chiều";
            this.rbt2chieu.UseVisualStyleBackColor = false;
            // 
            // rbt1chieu
            // 
            this.rbt1chieu.AutoSize = true;
            this.rbt1chieu.BackColor = System.Drawing.Color.Purple;
            this.rbt1chieu.Checked = true;
            this.rbt1chieu.Location = new System.Drawing.Point(19, 27);
            this.rbt1chieu.Margin = new System.Windows.Forms.Padding(4);
            this.rbt1chieu.Name = "rbt1chieu";
            this.rbt1chieu.Size = new System.Drawing.Size(133, 24);
            this.rbt1chieu.TabIndex = 14;
            this.rbt1chieu.TabStop = true;
            this.rbt1chieu.Text = "Nội suy 1 chiều";
            this.rbt1chieu.UseVisualStyleBackColor = false;
            this.rbt1chieu.CheckedChanged += new System.EventHandler(this.rbt1chieu_CheckedChanged);
            // 
            // txty2
            // 
            this.txty2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txty2.Location = new System.Drawing.Point(404, 66);
            this.txty2.Margin = new System.Windows.Forms.Padding(4);
            this.txty2.Name = "txty2";
            this.txty2.Size = new System.Drawing.Size(96, 26);
            this.txty2.TabIndex = 5;
            // 
            // txtx1y2
            // 
            this.txtx1y2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtx1y2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx1y2.Location = new System.Drawing.Point(404, 118);
            this.txtx1y2.Margin = new System.Windows.Forms.Padding(4);
            this.txtx1y2.Name = "txtx1y2";
            this.txtx1y2.Size = new System.Drawing.Size(96, 26);
            this.txtx1y2.TabIndex = 7;
            // 
            // txtxy
            // 
            this.txtxy.BackColor = System.Drawing.SystemColors.Window;
            this.txtxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtxy.Location = new System.Drawing.Point(289, 164);
            this.txtxy.Margin = new System.Windows.Forms.Padding(4);
            this.txtxy.Name = "txtxy";
            this.txtxy.Size = new System.Drawing.Size(96, 26);
            this.txtxy.TabIndex = 20;
            // 
            // txtx2
            // 
            this.txtx2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx2.Location = new System.Drawing.Point(54, 210);
            this.txtx2.Margin = new System.Windows.Forms.Padding(4);
            this.txtx2.Name = "txtx2";
            this.txtx2.Size = new System.Drawing.Size(96, 26);
            this.txtx2.TabIndex = 2;
            // 
            // txtx2y1
            // 
            this.txtx2y1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtx2y1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx2y1.Location = new System.Drawing.Point(176, 210);
            this.txtx2y1.Margin = new System.Windows.Forms.Padding(4);
            this.txtx2y1.Name = "txtx2y1";
            this.txtx2y1.Size = new System.Drawing.Size(96, 26);
            this.txtx2y1.TabIndex = 8;
            // 
            // txty
            // 
            this.txty.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txty.Location = new System.Drawing.Point(289, 66);
            this.txty.Margin = new System.Windows.Forms.Padding(4);
            this.txty.Name = "txty";
            this.txty.Size = new System.Drawing.Size(96, 26);
            this.txty.TabIndex = 4;
            // 
            // txtx
            // 
            this.txtx.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx.Location = new System.Drawing.Point(54, 164);
            this.txtx.Margin = new System.Windows.Forms.Padding(4);
            this.txtx.Name = "txtx";
            this.txtx.Size = new System.Drawing.Size(96, 26);
            this.txtx.TabIndex = 1;
            // 
            // txty1
            // 
            this.txty1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txty1.Location = new System.Drawing.Point(176, 66);
            this.txty1.Margin = new System.Windows.Forms.Padding(4);
            this.txty1.Name = "txty1";
            this.txty1.Size = new System.Drawing.Size(96, 26);
            this.txty1.TabIndex = 3;
            // 
            // txtx1
            // 
            this.txtx1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx1.Location = new System.Drawing.Point(54, 118);
            this.txtx1.Margin = new System.Windows.Forms.Padding(4);
            this.txtx1.Name = "txtx1";
            this.txtx1.Size = new System.Drawing.Size(96, 26);
            this.txtx1.TabIndex = 0;
            // 
            // txtx1y1
            // 
            this.txtx1y1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtx1y1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtx1y1.Location = new System.Drawing.Point(176, 118);
            this.txtx1y1.Margin = new System.Windows.Forms.Padding(4);
            this.txtx1y1.Name = "txtx1y1";
            this.txtx1y1.Size = new System.Drawing.Size(96, 26);
            this.txtx1y1.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnXoa.Location = new System.Drawing.Point(404, 262);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 36);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThem.Location = new System.Drawing.Point(176, 262);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 36);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm >>";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSua.Location = new System.Drawing.Point(289, 262);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 36);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnVertical
            // 
            this.btnVertical.BackColor = System.Drawing.Color.White;
            this.btnVertical.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVertical.BackgroundImage")));
            this.btnVertical.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVertical.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVertical.Location = new System.Drawing.Point(315, 110);
            this.btnVertical.Margin = new System.Windows.Forms.Padding(4);
            this.btnVertical.Name = "btnVertical";
            this.btnVertical.Size = new System.Drawing.Size(40, 36);
            this.btnVertical.TabIndex = 10;
            this.btnVertical.UseVisualStyleBackColor = false;
            this.btnVertical.Click += new System.EventHandler(this.btnVertical_Click);
            // 
            // btnHorizon
            // 
            this.btnHorizon.BackColor = System.Drawing.Color.White;
            this.btnHorizon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHorizon.BackgroundImage")));
            this.btnHorizon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHorizon.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnHorizon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnHorizon.Location = new System.Drawing.Point(204, 159);
            this.btnHorizon.Margin = new System.Windows.Forms.Padding(4);
            this.btnHorizon.Name = "btnHorizon";
            this.btnHorizon.Size = new System.Drawing.Size(40, 36);
            this.btnHorizon.TabIndex = 10;
            this.btnHorizon.UseVisualStyleBackColor = false;
            this.btnHorizon.Click += new System.EventHandler(this.btnHorizon_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClear.Location = new System.Drawing.Point(7, 262);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(40, 36);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTinh
            // 
            this.btnTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTinh.Location = new System.Drawing.Point(54, 262);
            this.btnTinh.Margin = new System.Windows.Forms.Padding(4);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(96, 36);
            this.btnTinh.TabIndex = 10;
            this.btnTinh.Text = "Tính";
            this.btnTinh.UseVisualStyleBackColor = false;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // labY2
            // 
            this.labY2.AutoSize = true;
            this.labY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labY2.Location = new System.Drawing.Point(432, 29);
            this.labY2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labY2.Name = "labY2";
            this.labY2.Size = new System.Drawing.Size(29, 20);
            this.labY2.TabIndex = 0;
            this.labY2.Text = "Y2";
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labY.Location = new System.Drawing.Point(325, 29);
            this.labY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(20, 20);
            this.labY.TabIndex = 0;
            this.labY.Text = "Y";
            // 
            // labX2
            // 
            this.labX2.AutoSize = true;
            this.labX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labX2.Location = new System.Drawing.Point(15, 213);
            this.labX2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labX2.Name = "labX2";
            this.labX2.Size = new System.Drawing.Size(29, 20);
            this.labX2.TabIndex = 0;
            this.labX2.Text = "X2";
            // 
            // labX
            // 
            this.labX.AutoSize = true;
            this.labX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labX.Location = new System.Drawing.Point(15, 167);
            this.labX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(20, 20);
            this.labX.TabIndex = 0;
            this.labX.Text = "X";
            // 
            // labX1
            // 
            this.labX1.AutoSize = true;
            this.labX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labX1.Location = new System.Drawing.Point(15, 121);
            this.labX1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labX1.Name = "labX1";
            this.labX1.Size = new System.Drawing.Size(29, 20);
            this.labX1.TabIndex = 0;
            this.labX1.Text = "X1";
            // 
            // labY1
            // 
            this.labY1.AutoSize = true;
            this.labY1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labY1.Location = new System.Drawing.Point(206, 29);
            this.labY1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labY1.Name = "labY1";
            this.labY1.Size = new System.Drawing.Size(29, 20);
            this.labY1.TabIndex = 0;
            this.labY1.Text = "Y1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKQ);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(535, 567);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách kết quả";
            // 
            // dgvKQ
            // 
            this.dgvKQ.AllowUserToOrderColumns = true;
            this.dgvKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.x,
            this.y,
            this.kq,
            this.x1,
            this.x2,
            this.y1,
            this.y2,
            this.x1y1,
            this.x1y2,
            this.x2y1,
            this.x2y2});
            this.dgvKQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKQ.Location = new System.Drawing.Point(4, 23);
            this.dgvKQ.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKQ.Name = "dgvKQ";
            this.dgvKQ.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKQ.Size = new System.Drawing.Size(527, 540);
            this.dgvKQ.TabIndex = 0;
            this.dgvKQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKQ_CellClick);
            this.dgvKQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvKQ_KeyDown);
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.Name = "stt";
            this.stt.Width = 50;
            // 
            // x
            // 
            this.x.HeaderText = "X";
            this.x.Name = "x";
            this.x.Width = 60;
            // 
            // y
            // 
            this.y.HeaderText = "Y";
            this.y.Name = "y";
            this.y.Width = 60;
            // 
            // kq
            // 
            this.kq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kq.HeaderText = "KQ";
            this.kq.MinimumWidth = 70;
            this.kq.Name = "kq";
            // 
            // x1
            // 
            this.x1.HeaderText = "X1";
            this.x1.Name = "x1";
            this.x1.Width = 60;
            // 
            // x2
            // 
            this.x2.HeaderText = "X2";
            this.x2.Name = "x2";
            this.x2.Width = 60;
            // 
            // y1
            // 
            this.y1.HeaderText = "Y1";
            this.y1.Name = "y1";
            this.y1.Width = 60;
            // 
            // y2
            // 
            this.y2.HeaderText = "Y2";
            this.y2.Name = "y2";
            this.y2.Width = 60;
            // 
            // x1y1
            // 
            this.x1y1.HeaderText = "X1Y1";
            this.x1y1.Name = "x1y1";
            this.x1y1.Width = 60;
            // 
            // x1y2
            // 
            this.x1y2.HeaderText = "X1Y2";
            this.x1y2.Name = "x1y2";
            this.x1y2.Width = 60;
            // 
            // x2y1
            // 
            this.x2y1.HeaderText = "X2Y1";
            this.x2y1.Name = "x2y1";
            this.x2y1.Width = 60;
            // 
            // x2y2
            // 
            this.x2y2.HeaderText = "X2Y2";
            this.x2y2.Name = "x2y2";
            this.x2y2.Width = 60;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1057, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.newToolStripMenuItem.Text = "&New ( Ctrl+ N )";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openToolStripMenuItem.Text = "&Open ( Ctrl+ O )";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveToolStripMenuItem.Text = "&Save ( Ctrl+ S )";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.saveAsToolStripMenuItem.Text = "Save As ( Ctrl+ Shift +S )";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToExcelToolStripMenuItem.Image")));
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exportToExcelToolStripMenuItem.Text = "&Export to Excel ( Ctrl+ E )";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorThemsToolStripMenuItem,
            this.addContentsToolStripMenuItem,
            this.changFormSizeToolStripMenuItem});
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // colorThemsToolStripMenuItem
            // 
            this.colorThemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("colorThemsToolStripMenuItem.Image")));
            this.colorThemsToolStripMenuItem.Name = "colorThemsToolStripMenuItem";
            this.colorThemsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorThemsToolStripMenuItem.Text = "Color Theme";
            this.colorThemsToolStripMenuItem.Click += new System.EventHandler(this.ColorThemsToolStripMenuItem_Click);
            // 
            // addContentsToolStripMenuItem
            // 
            this.addContentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addContentsToolStripMenuItem.Image")));
            this.addContentsToolStripMenuItem.Name = "addContentsToolStripMenuItem";
            this.addContentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addContentsToolStripMenuItem.Text = "Add Contents";
            this.addContentsToolStripMenuItem.Click += new System.EventHandler(this.AddContentsToolStripMenuItem_Click);
            //
            //changFormSizeToolStripMenuItem
            //
            this.changFormSizeToolStripMenuItem.Name = "changeFormSizeToolStripMenuItem";
           // 
           
            this.changFormSizeToolStripMenuItem.Click += new System.EventHandler(this.PictureBox2_Click);

            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.closeToolStripMenuItem.Text = "Close ( Alt +F4 )";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ddToolStripMenuItem.Text = "dd";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1057, 591);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PHẦN MỀM TÍNH NỘI SUY Pro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labY1;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.TextBox txtx2y2;
        private System.Windows.Forms.TextBox txtx1y2;
        private System.Windows.Forms.TextBox txtxy;
        private System.Windows.Forms.TextBox txtx2y1;
        private System.Windows.Forms.TextBox txtx1y1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Label labY2;
        private System.Windows.Forms.Label labY;
        private System.Windows.Forms.Label labX2;
        private System.Windows.Forms.Label labX;
        private System.Windows.Forms.Label labX1;
        private System.Windows.Forms.RadioButton rbt2chieu;
        private System.Windows.Forms.RadioButton rbt1chieu;
        private System.Windows.Forms.TextBox txty2;
        private System.Windows.Forms.TextBox txtx2;
        private System.Windows.Forms.TextBox txty;
        private System.Windows.Forms.TextBox txtx;
        private System.Windows.Forms.TextBox txty1;
        private System.Windows.Forms.TextBox txtx1;
        private System.Windows.Forms.DataGridView dgvKQ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn kq;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2;
        private System.Windows.Forms.DataGridViewTextBoxColumn y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn y2;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1y2;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2y2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labAuthor;
        private System.Windows.Forms.Button btnVertical;
        private System.Windows.Forms.Button btnHorizon;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addYourNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorThemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changFormSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ddToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxSize;
        private System.Windows.Forms.ToolTip toolTipPictureBoxSize;
    }
}

