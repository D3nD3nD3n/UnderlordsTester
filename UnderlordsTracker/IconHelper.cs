using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderlordsTester
{
    static class IconHelper
    {
        private static Image CropImage(Image img, Rectangle cropArea)//https://stackoverflow.com/questions/734930/how-to-crop-an-image-using-c
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Image GetImageByID(int id)
        {
            int column = 0;
            if (id / 10000 == 1)
            {
                column++;
            }
            id %= 10000;
            if (id / 500 == 1)
            {
                column++;
            }
            id %= 500;
            Point p = new Point(id % 10, id / 10);
            return CropImage(UnderlordsTester.Properties.Resources.Icons, new Rectangle((p.X * 32) + 320 * column, p.Y * 32, 32, 32));
        }
        public static Image GetMiniImageByID(int id)
        {
            int column = 0;
            if (id / 10000 == 1)
            {
                column++;
            }
            id %= 10000;
            if (id / 500 == 1)
            {
                column++;
            }
            id %= 500;
            Point p = new Point(id % 10, id / 10);
            return CropImage(UnderlordsTester.Properties.Resources.IconsMini, new Rectangle((p.X * 16) + 160 * column, p.Y * 16, 16, 16));
        }
        public static Image CombineImagePair(Image main, Image sub)
        {
            Bitmap output = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(output))
            {
                g.DrawImage(main, new Point(0, 0));
                g.DrawImage(sub, new Point(0, 17));
            }
            return output;
        }
    }
}
