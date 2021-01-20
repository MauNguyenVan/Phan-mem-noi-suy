using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
   internal static class  Utils
    {
        internal static bool IsPointInBouding(Point pointCheck, Point boundingStart, Point boundingEnd )
        {
            bool isIn = false;
            if( pointCheck.X>=  boundingStart.X && pointCheck.Y >= boundingStart.Y
               &&  pointCheck.X <= boundingEnd.X && pointCheck.Y <= boundingEnd.Y
                )
            {
                isIn = true;
            }
            return isIn;
        }
    }
}
