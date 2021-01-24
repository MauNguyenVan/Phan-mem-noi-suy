using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.DataClass
{
    internal static class Utils
    {
       
        internal static object UpdateObject(object object1, object object2)
        {
            
            //  Vector vector1 = new Vector(20, 30);
           

            return new object();
        }

        internal static object HightLightBorder(Control control)
        {

            //  Vector vector1 = new Vector(20, 30);
            Graphics graphics = control.CreateGraphics();
            Pen pen = new Pen(Color.Blue);
            Rectangle rectangle = new Rectangle(control.Location,new Size( control.Width -50, control.Height));
           
            graphics.DrawRectangle(pen, rectangle);
            

            return new object();
        }
    }
}
