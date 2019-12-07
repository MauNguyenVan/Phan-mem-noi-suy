using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
namespace WindowsFormsApp1
{
   public class SettingInfo
    {
        public int firtvalue = 2;
        public float secondValue = 3f;
        public string thirdValue = "Mậu đẹp choai";
       public string fourthVaue = "Hoa xinh gai";
       
        public int Width { get; set; }
        public void  getWidth(string x1)
        {

            //FileStream fs = new FileStream("Setting.MauDepChoai", FileMode.Create, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs);
            //x1 = "Mau dep trai";
            //XmlSerializer seri = new XmlSerializer(typeof(Form1));
            //seri.Serialize(fs, f1);
            //fs.Close();
            //MessageBox.Show("OK");
        }


    }
}
