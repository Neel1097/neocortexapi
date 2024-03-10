using System;
using System.Drawing;
using ScottPlot.Drawing.Colormaps;

class BitmapSimilarity
{
    static void Main()
    {
        // Replace these file paths with the paths to your bitmap images
        string imagePath1 = "F:\\Software desktop\\Team-ByteBaite_neocortexapi\\source\\Samples\\NeoCortexApiSample\\bin\\Debug\\net8.0\\outputFolder\\0.png";
        string imagePath2 = "F:\\Software desktop\\Team-ByteBaite_neocortexapi\\source\\Samples\\NeoCortexApiSample\\bin\\Debug\\net8.0\\outputFolder\\0-output.png";

        Bitmap bitmap1 = new Bitmap(imagePath1);
        Bitmap bitmap2 = new Bitmap(imagePath2);
    }

}