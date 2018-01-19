using System;
using System.IO;
using ImageMagick;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            MagickNET.SetGhostscriptDirectory("ghostscript");

            PdfToImage();

            //using (MagickImage image = new MagickImage("gatto.jpg"))
            //{
            //    image.Resize(50, 50);
            //    FileInfo fi = new FileInfo(@"gatto_resize2.jpg");
            //    image.Write(fi);
            //}

            //using (MagickImage image = new MagickImage(@"C:\tmp\doc.pdf"))
            //{
            //    image.Write("test.pdf");
            //    //FileInfo fi = new FileInfo(@"gatto_resize2.jpg");
            //    //image.Write(fi);
            //}

            Console.WriteLine("Fatto");
        }



        private static void PdfToImage()
        {
            MagickReadSettings settings = new MagickReadSettings();
            // Settings the density to 300 dpi will create an image with a better quality
            settings.Density = new Density(300, 300);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add all the pages of the pdf file to the collection
                images.Read(@"C:\tmp\doc.pdf", settings);

                int page = 1;
                foreach (MagickImage image in images)
                {
                    image.Resize(150, 150);
                    // Write page to file that contains the page number
                    image.Write("Snakeware.Page" + page + ".png");
                    // Writing to a specific format works the same as for a single image
                    //image.Format = MagickFormat.Ptif;
                    //image.Write("Snakeware.Page" + page + ".tif");
                    page++;
                }
            }
        }
    }
}
