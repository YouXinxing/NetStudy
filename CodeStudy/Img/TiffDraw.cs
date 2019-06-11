using BitMiracle.LibTiff.Classic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CodeStudy.Img
{
    public class TiffDraw
    {
        public static void GetImgTest()
        {
             var bitmapSource  = TiffToBitmap(@"D:\Sources\WorkSpace\NetStudy\CodeStudy\Resource\0607-6-2-2-37B.tif");
        }

        private static BitmapSource TiffToBitmap(string fileName)
        {
            Tiff tif = Tiff.Open(fileName, "r");
            if (tif == null)
            {
                return null;
            }
            // Find the width and height of the image
            FieldValue[] value = tif.GetField(TiffTag.IMAGEWIDTH);
            int width = value[0].ToInt();

            value = tif.GetField(TiffTag.IMAGELENGTH);
            int height = value[0].ToInt();

            // Read the image into the memory buffer
            int[] raster = new int[height * width];

            if (!tif.ReadRGBAImage(width, height, raster))
            {
                tif.Close();
                tif.Dispose();
                return null;
            }
            tif.Close();
            tif.Dispose();

            WriteableBitmap _wb = new WriteableBitmap(width, height, 96, 96, PixelFormats.Pbgra32, null);
            Int32Rect _rect = new Int32Rect(0, 0, _wb.PixelWidth, _wb.PixelHeight);
            int _bytesPerPixel = (_wb.Format.BitsPerPixel + 7) / 8;
            int _stride = _wb.PixelWidth * _bytesPerPixel;
            int _arraySize = _stride * _wb.PixelHeight;
            byte[] bits = new byte[_arraySize];
            for (int y = 0; y < _wb.PixelHeight; y++)
            {
                int rasterOffset = y * _wb.PixelWidth;
                int bitsOffset = (_wb.PixelHeight - y - 1) * _stride;

                for (int x = 0; x < _wb.PixelWidth; x++)
                {
                    int rgba = raster[rasterOffset++];
                    bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
                    bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
                    bits[bitsOffset++] = (byte)(rgba & 0xff);
                    bits[bitsOffset++] = (byte)((rgba >> 24) & 0xff);
                }
            }

            _wb.WritePixels(_rect, bits, _stride, 0);

            return _wb;
        }
    }
}
