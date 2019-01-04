using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        Bitmap image = null;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnEncodeText_Click(object sender, EventArgs e)
        {
            var steg = new ImageStegonography(image);
            image = steg.CreateSignature();

            Thread.Sleep(100);
            image = steg.EncodeText(tbTextToEncode.Text);
            pictureBox1.Image = image;
            //image.Save(tbSavePath.Text, ImageFormat.Jpeg);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image|*.png";
            sfd.DefaultExt = "png";
            sfd.AddExtension = true;

            sfd.ShowDialog();
            MemoryStream ms = new MemoryStream();
            if (sfd.FileName != string.Empty)
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                File.WriteAllBytes(sfd.FileName, ms.ToArray());
                CheckForSten();
            }
        }

        private void btnDecodeText_Click(object sender, EventArgs e)
        {
            var img = new ImageStegonography(image);
            if (img.IsEncodedImage())
            {
                tbTextToEncode.Text = img.DecodeText();
                CheckForSten();
            } else
            {
                MessageBox.Show("No encoding detected");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName == "") return;
            image = (Bitmap)Image.FromFile(ofd.FileName, true);
            pictureBox1.Image = image;
            CheckForSten();
        }
        private bool CheckForSten()
        {
            var imgs = new ImageStegonography(image);
            if (imgs.IsEncodedImage())
            {
                btnValidated.BackColor = Color.Green;
                return true;
            }
            else
            {
                btnValidated.BackColor = Color.Red;
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                image = (Bitmap)Clipboard.GetImage();
                pictureBox1.Image = image;
            }
        }

        private void btnValidated_Click(object sender, EventArgs e)
        {
            CheckForSten();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var steg = new ImageStegonography(image);
            image = steg.CreateSignature();
        }

        private void btnEncodeAudio_Click(object sender, EventArgs e)
        {
            var steg = new ImageStegonography(image);
            image = steg.CreateSignature();
            image = steg.EncodeBinary(File.ReadAllBytes(tbBinaryFile.Text));
            pictureBox1.Image = image;
        }

        private void btnDecodeFile_Click(object sender, EventArgs e)
        {
            var steg = new ImageStegonography(image);
            var filebytes = steg.DecodeBinary();
            File.WriteAllBytes(@"d:\test.mp3",filebytes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image|*.png";
            sfd.DefaultExt = "png";
            sfd.AddExtension = true;

            sfd.ShowDialog();
            MemoryStream ms = new MemoryStream();
            if (sfd.FileName != string.Empty)
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                File.WriteAllBytes(sfd.FileName, ms.ToArray());
                CheckForSten();
            }
        }
    }

}

