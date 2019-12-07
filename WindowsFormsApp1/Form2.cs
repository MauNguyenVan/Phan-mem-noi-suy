using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    delegate void aa(string a);
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

       public  void a2(string a)
        {
            MessageBox.Show(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            aa a2 = new aa(f1.b);
            a2(f1.Text);
        }
    }
}
