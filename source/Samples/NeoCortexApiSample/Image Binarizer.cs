using NeoCortex;
using System;
using Daenet.ImageBinarizerLib;
using Daenet.ImageBinarizerLib.Entities;

namespace Image_Binarizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "";
            string outputPath = ""; // Specify your desired output path
            int threshold = 130; // Set the binarization threshold

            NeoCortexUtils.BinarizeImage(imagePath, outputPath, threshold, "");

            string textFilePath = ""; // Path to the text file

            // Process the binary array as needed
        }
    }
}