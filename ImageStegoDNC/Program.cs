using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageStegoDNC
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] != string.Empty)
                {
                    Console.WriteLine($"Checking for Encoding on {args[0]}");
                    if (File.Exists(args[0]))
                    {
                        var image = Image.FromFile(args[0]);
                        var isteg = new ImageStego.Net.ImageStegonography((Bitmap)image);
                        if (isteg.IsEncodedImage())
                        {
                            Console.WriteLine("This image is ready to be decoded");
                            Console.WriteLine(isteg.DecodeText());

                        }
                        else
                        {
                            Console.WriteLine("Enter Message to Encode:");
                            var result = Console.ReadLine();
                            var resimage = isteg.EncodeText(result);
                            Console.WriteLine("Enter filename for encoded image (w/o extension):");
                            result = Console.ReadLine();
                            isteg.GetImage().Save(result + ".png", ImageFormat.Png);
                            var aftercheck = isteg.IsEncodedImage();
                        }
                    }
                    else Console.WriteLine($"File not found - {args[0]}.");
                }
                Console.WriteLine("Press a key to exit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You must pass in an image path to use.");
            }
            Console.ReadKey();
        }

    }
}
