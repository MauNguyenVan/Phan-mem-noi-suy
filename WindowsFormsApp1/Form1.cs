using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
           Form2 f2 = new Form2();

            // aa aaa = f2.a2;
            //  aaa("qwrty");
            f2.Show();
            f2.a2("fdfdfdfdfd");
        }
        public void b(string b)
        {
            MessageBox.Show(b); ;
        }

        private void BtnDeserialize_Click(object sender, EventArgs e)
        {
           
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

            DeSerializer();
          

        }

       // [System.Diagnostics.Conditional("DEBUG")]
        private void Serializer()
        {

      

        }
        private void DeSerializer()
        {
    
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
