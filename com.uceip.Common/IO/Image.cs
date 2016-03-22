using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace com.uceip.Common.IO
{
    public class Image
    {
        /// <summary>
        /// 生成图片 
        /// </summary>
        /// <param name="content">图片内容</param>
        /// <param name="dir">保存路径</param>
        /// <param name="width">图片宽度(大于content的长度*pix)</param>
        /// <param name="height">图片高度(必须大于pix)</param>
        /// <param name="pix">文字大小(度量单位为像素)</param>
        public void SaveImage(string content, string dir, int width, int height, int pix)
        {
            //生成图片
            Bitmap bitmap = CreateImage(content, width, height, pix);
            //将图片保存到路径dir
            bitmap.Save(dir, ImageFormat.Jpeg);
        }

        /// <summary>
        /// 生成图片
        /// </summary>
        /// <param name="content">图片内容</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <returns>生成的图片(Bitmap对象)</returns>
        private Bitmap CreateImage(string content, int width, int height, int pix)
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);

            g.Clear(Color.White);
            //给图片加入内容
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, bm.Width, bm.Height), Color.Black, Color.Black, 1.2f, true);
            PointF pf = new PointF();
            pf.X = (width - (content.Length * pix)) / 2;
            pf.Y = (height - pix) / 2;
            g.DrawString(content, new Font("宋体", pix, GraphicsUnit.Pixel), brush, pf);

            return bm;
        }
    }
}
