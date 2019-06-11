using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Img
{
    public class ImgDraw
    {
        public static void GetImg()
        {
            string bottompath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\bottom.png";
            string toppath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\top.png";
            string path = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\BD7F8920D5061F71082756B122FA9101.JPG";
           
            Image imgSrc = Image.FromFile(path);
            Image bottomimgWarter = Image.FromFile(bottompath);
            Image topimgWarter = Image.FromFile(toppath);

            using (Graphics g = Graphics.FromImage(imgSrc))
            {


                g.DrawImage(bottomimgWarter, new Rectangle(0,
                                                 imgSrc.Height - bottomimgWarter.Height,
                                                 bottomimgWarter.Width,
                                                 bottomimgWarter.Height),
                        0, 0, bottomimgWarter.Width, bottomimgWarter.Height, GraphicsUnit.Pixel);

                //g.DrawImage(bottomimgWarter, new Rectangle(0,
                //                                bottomimgWarter.Height,
                //                                bottomimgWarter.Width,
                //                                bottomimgWarter.Height),
                //        0, 0, bottomimgWarter.Width, bottomimgWarter.Height, GraphicsUnit.Pixel);


                g.DrawImage(topimgWarter, new Rectangle(0,
                                            45,
                                            topimgWarter.Width,
                                            topimgWarter.Height),
                   0, 0, topimgWarter.Width, topimgWarter.Height, GraphicsUnit.Pixel);
            }

            //Graphics g = Graphics.FromImage(imgSrc); 
            



            string newpath = string.Format(@"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\{0}.png", Guid.NewGuid().ToString());
            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
           

        }

        public static void GetImgTest()
        {
            string bottompath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\bottom.png";
            string toppath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\top.png";
            string path = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\BD7F8920D5061F71082756B122FA9101.JPG";

            Image imgSrc = Image.FromFile(path);
            Image bottomimgWarter = Image.FromFile(bottompath);
            Image topimgWarter = Image.FromFile(toppath);

            using (Graphics g = Graphics.FromImage(imgSrc))
            {

                Color color = Color.Red ; 
                g.DrawEllipse(new Pen(color), new Rectangle(0,
                                                 imgSrc.Height - bottomimgWarter.Height,
                                                 bottomimgWarter.Width,
                                                 bottomimgWarter.Height));

                g.DrawImage(topimgWarter, new Rectangle(0,
                                           0,
                                           topimgWarter.Width,
                                           topimgWarter.Height),
                  0, 0, topimgWarter.Width, topimgWarter.Height, GraphicsUnit.Pixel);

            }
             

            string newpath = string.Format(@"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\{0}.png", Guid.NewGuid().ToString());
            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg); 
        }



        public static void ChangeImgTest()
        {
            string bottompath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\bottom.png";
            string toppath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\top.png";
            string path = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\f59cdad0beb24aa385819869353b3449.png";

            string despath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\sfdasdfa.png";

            string desbottompath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\bottom2.png";
            string destoppath = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\top2.png";
            string newurl = @"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\sds.png";

            ChangeImagAlpha(path, (int)(255 * 0.25), despath);
            //ChangeImagAlpha(toppath, (int)(255 * 0.15), destoppath);

            Image imgSrc = Image.FromFile(newurl);

            Image bottomimgWarter = Image.FromFile(despath); 
            //Image topimgWarter = Image.FromFile(toppath);

            using (Graphics g = Graphics.FromImage(imgSrc))
            {

                Color color = Color.Red;

                g.DrawImage(bottomimgWarter, new Rectangle(0,
                                                 0,
                                                 bottomimgWarter.Width,
                                                 bottomimgWarter.Height),
                        0, 0, bottomimgWarter.Width, bottomimgWarter.Height, GraphicsUnit.Pixel);

                //g.DrawImage(topimgWarter, new Rectangle(0,
                //                           0,
                //                           topimgWarter.Width,
                //                           topimgWarter.Height),
                //  0, 0, topimgWarter.Width, topimgWarter.Height, GraphicsUnit.Pixel);

            } 
            string newpath = string.Format(@"E:\UploadTest\65d1221a932342dca327ad9bfa3c765f\{0}.png", Guid.NewGuid().ToString());
            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Png); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static bool ChangeImagAlpha(string filepath, int alpha,string desfilepath)
        {
            bool success = false;
            try
            {
                Bitmap src = new Bitmap(filepath);
                Bitmap bmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                for (int h = 0; h < src.Height; h++)
                    for (int w = 0; w < src.Width; w++)
                    {
                        Color c = src.GetPixel(w, h);
                        bmp.SetPixel(w, h, Color.FromArgb(alpha, c.R, c.G, c.B));//色彩度最大为255，最小为0
                    }
                bmp.Save(desfilepath);
                success = true;
            }
            catch(Exception ex)
            {
                success = false;
            }
           
            return success;
        }

         
    }
}
