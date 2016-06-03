using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Helpers;

namespace WebApplication3.Controllers
{
    public class ImageHelper
    {
     

        public static byte[] ReImage(byte[] buffer, double maxWidth , double maxHeight)
        {
            WebImage img = new WebImage(buffer);
            int[] newWH = imgReSize(img.Width, img.Height, maxWidth, maxHeight);
            return img.Resize(newWH[0], newWH[1]).GetBytes();
        }


        private static int[] imgReSize(double width, double height, double maxWidth, double maxHight)
        {
            int[] newWH = new int[2];

            double rate, rWidth, rHeight;

            if (width > height && width > maxWidth)
            {
                //水平圖
                rWidth = maxWidth;
                rate = rWidth / width;
                rHeight = height * rate;
                newWH[0] = (int)rWidth;
                newWH[1] = (int)rHeight;
            }
            else if (height > width && height > maxHight)
            {
                //垂直圖
                rHeight = maxHight;
                rate = rHeight / height;
                rWidth = width * rate;
                newWH[0] = (int)rWidth;
                newWH[1] = (int)rHeight;
            }
            else
            {
                newWH[0] = (int)width;
                newWH[1] = (int)height;
            }
            return newWH;
        }
    }
}