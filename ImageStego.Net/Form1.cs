using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageStego.Net
{
    public partial class Form1 : Form
    {
        private const int NUM_TRIALS = 10;
        public Form1()
        {
            InitializeComponent();
        }

        List<ValidatorSet> ValidatorSets = new List<ValidatorSet>();
        
        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.ImageLocation = @"C:\Users\Twist\Pictures\Camera Roll\20180922_113337_MixedReality.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //Try a small pic to be able to compare output, 
            //a big one to compare performance

        }
        public void doSomethingWithBitmapFast(System.Drawing.Bitmap bmp)
        {

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Bitmap bm = new Bitmap(pictureBox1.Image);
            for (int trial = 0; trial < NUM_TRIALS; trial++)
            {
                for (int Y = 0; Y < bm.Height; Y++)
                {
                    for (int X = 0; X < bm.Width; X++)
                    {
                        Color clr = bm.GetPixel(X, Y);
                        clr = Color.FromArgb(255 - clr.R, 255 - clr.G, 255 - clr.B);
                        bm.SetPixel(X, Y, Color.FromArgb(255,clr.R,clr.G, clr.B));
                    }
                }
            }
            pictureBox1.Image = bm;
            watch.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap b = (Bitmap)pictureBox1.Image;
            doSomethingWithBitmapFast(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);

            ValidatorSets.Clear();

            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 255, 0, 0), X = 20, Y = 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 255, 0), X = 20, Y = bm.Height - 20 });

            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 255, 0), X = bm.Width - 20, Y = 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 0, 0), X = bm.Width - 20, Y = bm.Height - 20 });

            if (bm.Height > 200 && bm.Width > 200)
            {
                var clr = Color.FromArgb(255, 255, 255);
                //var item = bm.GetPixel(20, 20);

                foreach (var item in ValidatorSets)
                {
                    bm.SetPixel(item.X, item.Y, item.Color);
                }

                pictureBox1.Image = bm;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);

            ValidatorSets.Clear();

            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 255, 0, 0), X = 20, Y = 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 255, 0), X = 20, Y = bm.Height - 20 });

            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 255, 0), X = bm.Width - 20, Y = 20 });
            ValidatorSets.Add(new ValidatorSet { Color = Color.FromArgb(255, 0, 0, 0), X = bm.Width - 20, Y = bm.Height - 20 });

            var resultCount = 0;
            
            if (bm.Height > 200 && bm.Width > 200)
            {
                var clr = Color.FromArgb(255, 255, 255);
                //var item = bm.GetPixel(20, 20);
                
                foreach (var item in ValidatorSets)
                {
                    var pix = bm.GetPixel(item.X, item.Y);
                    if (pix.A == item.Color.A &&
                        pix.R == item.Color.R &&
                        pix.G == item.Color.G &&
                        pix.B == item.Color.B) resultCount++;

                }

                if (resultCount == 4)
                {
                    btnValidated.BackColor = Color.Green;
                } else
                {
                    btnValidated.BackColor = Color.Red;
                }

                pictureBox1.Image = bm;

            }
        }

        private void btnEncodeText_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);

            var text = Encoding.UTF8.GetBytes(tbTextToEncode.Text);

            int x = 30;
            int y = 30;
            foreach (var bit in text)
            {
                var ogpixel = bm.GetPixel(x, y);
                bm.SetPixel(x, y, Color.FromArgb(255, bit, ogpixel.G, ogpixel.B ));
                ogpixel = bm.GetPixel(x, y);
                if (x < bm.Width) x += 10;
                else
                {
                    if (y + 10 > bm.Height)
                    {
                        MessageBox.Show("Unable to encode the entire message into the image.");
                        return;

                    }
                    else y += 10;
                    x = 30;
                }

            }
            pictureBox1.Image = bm;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);

  

            int x = 30;
            int y = 30;
            List<byte> bytes = new List<byte>();
            for (var i= 0; i < 9; i++)
            {
                var ogpixel = bm.GetPixel(x, y);
                bytes.Add(ogpixel.R);
                if (x < bm.Width) x += 10;
                else
                {
                    if (y + 10 > bm.Height)
                    {
                        MessageBox.Show("Unable to encode the entire message into the image.");
                        return;

                    }
                    else y += 10;
                    x = 30;
                }

            }
            var text = Encoding.UTF8.GetString(bytes.ToArray());
            tbTextToEncode.Text = text;
        }
    }

}

