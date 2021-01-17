using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NoiSuy
{
    public partial class frmFlashScreen : Form
    {
        public frmFlashScreen()
        {
            InitializeComponent();
            timer1.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void frmFlashScreen_Load(object sender, EventArgs e)
        {
          


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 45;
            progressBar1.Increment(2);
            progressBar1.Step = 5;
            lbl1.Text = "Đang khởi động " + progressBar1.Value + " %";
            this.Opacity = 1 - 0.01 * progressBar1.Value;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            }

            ////timer2.Interval = 40;//50x100=5000ms
            //progressBar1.Increment(1);
            //label1.Text = "Đang khởi động..." + progressBar1.Value + "%";
            ////if (progressBar1.Value == 100)
            ////{
            ////    timer2.Stop();
            ////}


        }
    }
}
