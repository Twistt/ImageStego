using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using PixelMapSharp;

namespace ImageStego.Net
{
    public class ImageStegonography
    {
        List<ValidatorSet> ValidatorSets = new List<ValidatorSet>();
        public Bitmap bm = null;
        PixelMap pm = null;
        private const int yoffset = 50;
        private const int xoffset = 50;
        public Image GetImage() {
            return pm.GetBitmap();
        }
        public ImageStegonography(Bitmap image)
        {
            this.bm = image;
            pm = new PixelMap(image);
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 192, 192, 192), X = 20, Y = 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 169, 169, 169), X = 20, Y = image.Height - 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 128, 128, 128), X = image.Width - 20, Y = 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 0, 0), X = image.Width - 20, Y = image.Height - 20 });
        }
        private Pixel GetPixel(int x, int y) {
            Pixel pixel = pm[x, y];
            return pixel;
        }
        private Pixel SetPixel(int x, int y, Color color)
        {
            pm[x, y] = new Pixel(color);
            return pm[x, y];

        }
        public string DecodeText()
        {
            //read data size
            var dataSize = new List<byte>();
            var i = 0;
            var endPixelsDetected = false;
            while (endPixelsDetected == false)
            {
                System.Drawing.Color sizepixel = GetPixel(i, 30).Color;
                dataSize.Add(sizepixel.R);
                if (GetPixel(i + 1, 30).R == 0 && GetPixel(i + 2, 30).R == 0)
                {
                    endPixelsDetected = true;
                }
                i++;
            }
            var totalDataSizeString = Encoding.UTF8.GetString(dataSize.ToArray());
            var totalDataSize = int.Parse(totalDataSizeString);

            int x = 30;
            int y = 30;
            List<byte> bytes = new List<byte>();
            for (var n = 0; n < totalDataSize; n++)
            {
                var ogpixel = GetPixel(x, y);
                bytes.Add(ogpixel.R);
                if (x + xoffset < bm.Width) x += xoffset;
                else
                {
                    if (y + yoffset > bm.Height)
                    {
                        Console.WriteLine("The message has been truncated.");
                        break;
                    }
                    else y += yoffset;
                    x = 30;
                }
            }
            var text = Encoding.UTF8.GetString(bytes.ToArray());
            return text;
        }
        public Bitmap EncodeText(string enctext)
        {
            bm = CreateSignature();

            var text = Encoding.UTF8.GetBytes(enctext);

            //write data size to prefix
            var dataSize = Encoding.UTF8.GetBytes(text.Length.ToString());
            var i = 0;
            foreach (var bit in dataSize)
            {
                var ogpixel = GetPixel(i, 30);
                SetPixel(i, 30, Color.FromArgb(255, bit, ogpixel.G, ogpixel.B));
                i++;
            }
            //write "end" package so we know the number is over
            var ogpixels = GetPixel(i, 30);
            SetPixel(i, 30, Color.FromArgb(255, 0, ogpixels.G, ogpixels.B));
            SetPixel(i + 1, 30, Color.FromArgb(255, 0, ogpixels.G, ogpixels.B));


            int x = 30;
            int y = 30;
            foreach (var bit in text)
            {
                var ogpixel = GetPixel(x, y);
                SetPixel(x, y, Color.FromArgb(255, bit, ogpixel.G, ogpixel.B));
                ogpixel = GetPixel(x, y);
                if (x + xoffset < bm.Width) x += xoffset;
                else
                {
                    if (y + yoffset > bm.Height)
                    {
                        Console.WriteLine("Unable to encode the entire message into the image.");
                        return null;

                    }
                    else y += yoffset;
                    x = 30;
                }

            }
            return bm;
        }
        public Bitmap CreateSignature()
        {

            if (bm.Height > 200 && bm.Width > 200)
            {

                foreach (var item in ValidatorSets)
                {
                    SetPixel(item.X, item.Y, item.Color);
                    var pixelcheck = GetPixel(item.X, item.Y);
                }
                if (!IsEncodedImage())
                {
                    Console.WriteLine("Message did not encode properly.");
                    return null;
                }
                return bm;

            }
            return null;
        }
        public bool IsEncodedImage()
        {
            var resultCount = 0;

            if (bm.Height > 200 && bm.Width > 200)
            {
                foreach (var item in ValidatorSets)
                {
                    var pix = GetPixel(item.X, item.Y);
                    if (pix.A == item.Color.A &&
                        pix.R == item.Color.R &&
                        pix.G == item.Color.G &&
                        pix.B == item.Color.B) resultCount++;
                    else return false;
                }

                if (resultCount == 4) return true;
                else return false;
                
            }
            return false;
        }
    }
}
