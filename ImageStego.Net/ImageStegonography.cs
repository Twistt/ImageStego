using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageStego.Net
{
    public class ImageStegonography
    {
        List<ValidatorSet> ValidatorSets = new List<ValidatorSet>();
        public Bitmap bm = null;
        private const int yoffset = 5;
        private const int xoffset = 5;
        public bool UseAlphaChannel = false;
        public ImageStegonography(Bitmap image)
        {
            this.bm = image.Clone(new Rectangle(new Point(), image.Size), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 192, 192, 192), X = 5, Y = 5 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 169, 169, 169), X = 5, Y = image.Height - 5 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 128, 128, 128), X = image.Width - 5, Y = 5 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 0, 0), X = image.Width - 5, Y = image.Height - 5 });
        }
        public byte[] DecodeBinary()
        {

            //read data size
            var dataSize = new List<byte>();
            var i = 0;
            var endPixelsDetected = false;
            while (endPixelsDetected == false)
            {
                var sizepixel = bm.GetPixel(i, 10).R;
                dataSize.Add(sizepixel);
                if (bm.GetPixel(i + 1, 10).R == 0 && bm.GetPixel(i + 2, 10).R == 0)
                {
                    endPixelsDetected = true;
                }
                i++;
            }
            var totalDataSizeString = Encoding.UTF8.GetString(dataSize.ToArray());
            var totalDataSize = int.Parse(totalDataSizeString);

            int x = 10;
            int y = 10;
            List<byte> bytes = new List<byte>();
            for (var n = 0; n < totalDataSize; n++)
            {
                var ogpixel = bm.GetPixel(x, y);
                bytes.Add(ogpixel.A);
                if (x + xoffset < bm.Width) x += xoffset;
                else
                {
                    if (y + yoffset+1 >= bm.Height)
                    {
                        MessageBox.Show("The message has been truncated.");
                        break;
                    }
                    else y += yoffset;
                    x = 10;
                }
            }
            return bytes.ToArray();
        }
        public string DecodeText()
        {

            //read data size
            var dataSize = new List<byte>();
            var i = 0;
            var endPixelsDetected = false;
            while (endPixelsDetected == false)
            {
                var sizepixel = bm.GetPixel(i, 10).R;
                dataSize.Add(sizepixel);
                if (bm.GetPixel(i + 1, 10).R == 0 && bm.GetPixel(i + 2, 10).R == 0)
                {
                    endPixelsDetected = true;
                }
                i++;
            }
            var totalDataSizeString = Encoding.UTF8.GetString(dataSize.ToArray());
            var totalDataSize = int.Parse(totalDataSizeString);

            int x = 10;
            int y = 10;
            List<byte> bytes = new List<byte>();
            for (var n = 0; n < totalDataSize; n++)
            {
                var ogpixel = bm.GetPixel(x, y);
                bytes.Add(ogpixel.R);
                if (x + xoffset < bm.Width) x += xoffset;
                else
                {
                    if (y + yoffset > bm.Height)
                    {
                        MessageBox.Show("The message has been truncated.");
                        break;
                    }
                    else y += yoffset;
                    x = 10;
                }
            }
            var text = Encoding.UTF8.GetString(bytes.ToArray());
            return text;
        }
        public Bitmap EncodeBinary(byte[] bytes)
        {
            bm = CreateSignature();

            //write data size to prefix
            var dataSize = bytes.Length.ToString();
            var i = 0;
            foreach (var bit in dataSize)
            {
                var ogpixel = bm.GetPixel(i, 10);
                bm.SetPixel(i, 10, Color.FromArgb(255, bit, ogpixel.G, ogpixel.B));
                i++;
            }
            //write "end" package so we know the number is over
            var ogpixels = bm.GetPixel(i, 10);
            bm.SetPixel(i, 10, Color.FromArgb(255, 0, ogpixels.G, ogpixels.B));
            bm.SetPixel(i + 1, 10, Color.FromArgb(255, 0, ogpixels.G, ogpixels.B));


            int x = 10;
            int y = 10;
            foreach (var bit in bytes)
            {
                var ogpixel = bm.GetPixel(x, y);
                bm.SetPixel(x, y, Color.FromArgb(bit, ogpixel.R, ogpixel.G, ogpixel.B));
                ogpixel = bm.GetPixel(x, y);
                if (x + xoffset < bm.Width) x += xoffset;
                else
                {
                    if (y + yoffset+1 >= bm.Height)
                    {
                        MessageBox.Show("Unable to encode the entire message into the image.");
                        return null;

                    }
                    else y += yoffset;
                    x = 10;
                }

            }
            return bm;
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
                var ogpixel = bm.GetPixel(i, 10);
                bm.SetPixel(i, 10, Color.FromArgb(255, bit, ogpixel.G, ogpixel.B));
                i++;
            }
            //write "end" package so we know the number is over
            var ogpixels = bm.GetPixel(i, 10);
            bm.SetPixel(i, 10, Color.FromArgb(255, 0, ogpixels.G, ogpixels.B));
            bm.SetPixel(i + 1, 10, Color.FromArgb(255, 0, ogpixels.G, ogpixels.B));


            int x = 10;
            int y = 10;
            foreach (var bit in text)
            {
                var ogpixel = bm.GetPixel(x, y);
                bm.SetPixel(x, y, Color.FromArgb(255, bit, ogpixel.G, ogpixel.B));
                ogpixel = bm.GetPixel(x, y);
                if (x + xoffset < bm.Width) x += xoffset;
                else
                {
                    if (y + yoffset > bm.Height)
                    {
                        MessageBox.Show("Unable to encode the entire message into the image.");
                        return null;

                    }
                    else y += yoffset;
                    x = 10;
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
                    bm.SetPixel(item.X, item.Y, item.Color);
                }
                if (!IsEncodedImage())
                {
                    MessageBox.Show("Message did not encode properly.");
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
                    var pix = bm.GetPixel(item.X, item.Y);
                    if (pix.A == item.Color.A &&
                        pix.R == item.Color.R &&
                        pix.G == item.Color.G &&
                        pix.B == item.Color.B) resultCount++;
                    else return false;
                   
                }

                if (resultCount == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
