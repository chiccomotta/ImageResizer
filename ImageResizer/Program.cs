using System;
using System.IO;
using ImageLibrary;
using ImageMagick;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Resizer.PdfToImage();

            Console.WriteLine("Fatto");
        }
    }
}
