using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.DataClass
{
    internal static class Utils
    {
        internal static (Point TopLeft, Point BottomDown) GetBounding(Point fistPoint, Point endPoint)
        {
            int width = Math.Abs(endPoint.X - fistPoint.X);
            int height = Math.Abs(endPoint.Y - fistPoint.Y);
            int topLeftX = fistPoint.X <= endPoint.X ? fistPoint.X : endPoint.X;
            int topLeftY = fistPoint.Y <= endPoint.Y ? fistPoint.Y : endPoint.Y;
            int bottonRightX = topLeftX + width;
            int bottonRightY = topLeftY + height;
            Point boudingStart = new(topLeftX, topLeftY);
            Point boundingEnd = new(bottonRightX, bottonRightY);
            return (boudingStart, boundingEnd);
        }
        internal static bool IsPointInBouding(Point pointCheck, Point boundingStart, Point boundingEnd)
        {
            bool isIn = false;
            if (pointCheck.X >= boundingStart.X && pointCheck.Y >= boundingStart.Y
               && pointCheck.X <= boundingEnd.X && pointCheck.Y <= boundingEnd.Y
                )
            {
                isIn = true;
            }
            return isIn;
        }
    }
}
