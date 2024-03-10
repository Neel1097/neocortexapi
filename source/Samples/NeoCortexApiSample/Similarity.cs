using System;
using System.Drawing;
using Accord.Imaging;
using Accord.Imaging.Comparing;
using Accord.Imaging.Converters;
using ScottPlot.Drawing.Colormaps;

class BitmapSimilarity
{
    static void Main()
    {
        // Replace these file paths with the paths to your bitmap images
        string imagePath1 = "F:\\Software desktop\\Team-ByteBaite_neocortexapi\\source\\Samples\\NeoCortexApiSample\\bin\\Debug\\net8.0\\outputFolder\\0.png";
        string imagePath2 = "F:\\Software desktop\\Team-ByteBaite_neocortexapi\\source\\Samples\\NeoCortexApiSample\\bin\\Debug\\net8.0\\outputFolder\\0:output.png";

        Bitmap bitmap1 = new Bitmap(imagePath1);
        Bitmap bitmap2 = new Bitmap(imagePath2);

        double similarity = CalculateImageSimilarity(bitmap1, bitmap2);

        Console.WriteLine($"Similarity between the two bitmaps: {similarity:P}");
    }

    static double CalculateImageSimilarity(Bitmap bmp1, Bitmap bmp2)
    {
        // Convert bitmaps to grayscale
        BitmapConverter converter = new BitmapConverter();
        Grayscale grayscale1 = converter.Convert(bmp1, typeof(Grayscale)) as Grayscale;
        Grayscale grayscale2 = converter.Convert(bmp2, typeof(Grayscale)) as Grayscale;

        // Create SSIM class instance
        StructuralSimilarity ssim = new StructuralSimilarity(grayscale1, grayscale2);

        // Calculate similarity
        double similarity = ssim.Metric;

        return similarity;
    }
}