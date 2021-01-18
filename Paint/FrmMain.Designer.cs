
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnRibbon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnPaint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnRibbon, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.55556F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnPaint
            // 
            this.pnPaint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnPaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPaint.Location = new System.Drawing.Point(4, 93);
            this.pnPaint.Name = "pnPaint";
            this.pnPaint.Size = new System.Drawing.Size(849, 386);
            this.pnPaint.TabIndex = 0;
            this.pnPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.pnPaint_Paint);
            this.pnPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseDown);
            this.pnPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseMove);
            this.pnPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseUp);
            // 
            // pnRibbon
            // 
            this.pnRibbon.BackColor = System.Drawing.SystemColors.Control;
            this.pnRibbon.Controls.Add(this.btnClear);
            this.pnRibbon.Controls.Add(this.btnColor);
            this.pnRibbon.Controls.Add(this.btnLine);
            this.pnRibbon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRibbon.Location = new System.Drawing.Point(4, 4);
            this.pnRibbon.Name = "pnRibbon";
            this.pnRibbon.Size = new System.Drawing.Size(849, 82);
            this.pnRibbon.TabIndex = 1;
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
    }
}

