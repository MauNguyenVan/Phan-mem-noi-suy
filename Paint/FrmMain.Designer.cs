
namespace Paint
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnPaint = new System.Windows.Forms.Panel();
            this.pnRibbon = new System.Windows.Forms.Panel();
            this.btnNone = new System.Windows.Forms.Button();
            this.numLightWidth = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.lsbElement = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.cbxLineType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnRibbon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLightWidth)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.pnPaint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnRibbon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsbElement, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnPaint
            // 
            this.pnPaint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnPaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPaint.Location = new System.Drawing.Point(4, 105);
            this.pnPaint.Name = "pnPaint";
            this.pnPaint.Size = new System.Drawing.Size(698, 374);
            this.pnPaint.TabIndex = 0;
            this.pnPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.pnPaint_Paint);
            this.pnPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseDown);
            this.pnPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseMove);
            this.pnPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseUp);
            this.pnPaint.Resize += new System.EventHandler(this.pnPaint_Resize);
            // 
            // pnRibbon
            // 
            this.pnRibbon.BackColor = System.Drawing.SystemColors.Control;
            this.pnRibbon.Controls.Add(this.cbxLineType);
            this.pnRibbon.Controls.Add(this.btnNone);
            this.pnRibbon.Controls.Add(this.numLightWidth);
            this.pnRibbon.Controls.Add(this.btnClear);
            this.pnRibbon.Controls.Add(this.btnColor);
            this.pnRibbon.Controls.Add(this.btnLine);
            this.pnRibbon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRibbon.Location = new System.Drawing.Point(4, 4);
            this.pnRibbon.Name = "pnRibbon";
            this.pnRibbon.Size = new System.Drawing.Size(698, 94);
            this.pnRibbon.TabIndex = 1;
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(0, 29);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(75, 23);
            this.btnNone.TabIndex = 5;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // numLightWidth
            // 
            this.numLightWidth.Location = new System.Drawing.Point(299, 2);
            this.numLightWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLightWidth.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numLightWidth.Name = "numLightWidth";
            this.numLightWidth.Size = new System.Drawing.Size(115, 23);
            this.numLightWidth.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(162, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(81, 0);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(0, 0);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // lsbElement
            // 
            this.lsbElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbElement.FormattingEnabled = true;
            this.lsbElement.ItemHeight = 15;
            this.lsbElement.Location = new System.Drawing.Point(709, 105);
            this.lsbElement.Name = "lsbElement";
            this.lsbElement.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbElement.Size = new System.Drawing.Size(144, 374);
            this.lsbElement.TabIndex = 2;
            this.lsbElement.SelectedIndexChanged += new System.EventHandler(this.lsbElement_SelectedIndexChanged);
            this.lsbElement.DoubleClick += new System.EventHandler(this.lsbElement_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(709, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 94);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxLineType
            // 
            this.cbxLineType.FormattingEnabled = true;
            this.cbxLineType.Location = new System.Drawing.Point(297, 34);
            this.cbxLineType.Name = "cbxLineType";
            this.cbxLineType.Size = new System.Drawing.Size(116, 23);
            this.cbxLineType.TabIndex = 6;
            this.cbxLineType.SelectedIndexChanged += new System.EventHandler(this.cbxLineType_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMain";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnRibbon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLightWidth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnPaint;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Panel pnRibbon;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.NumericUpDown numLightWidth;
        private System.Windows.Forms.ListBox lsbElement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.ComboBox cbxLineType;
    }
}

