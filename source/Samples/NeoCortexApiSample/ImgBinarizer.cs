using Daenet.ImageBinarizerLib;
using Daenet.ImageBinarizerLib.Entities;

public class ImgBinarizer
{
    public static double[] Imgo()
    {
        var parameters = new BinarizerParams
        {
            InputImagePath = "F:\\YOURDIRR\\Picture\\MNIST_6_0.png",
            ImageHeight = 238,
            ImageWidth = 238,
            //BlueThreshold = 200,
            //RedThreshold = 200,
            //GreenThreshold = 200
        };
        //string imagePath = "F:\\YOURDIRR\\Picture\\MNIST_6_0.png";
        //string outputPath = "F:\\YOURDIRR\\Picture"; //Specify your desired output path
        ImageBinarizer bizer = new ImageBinarizer(parameters);

        var doubleArray = bizer.GetArrayBinary();
        var hg = doubleArray.GetLength(1);
        var wd = doubleArray.GetLength(0);
        var intArray = new double[hg * wd];
        for (int j = 0; j < hg; j++)
        {
            for (int i = 0; i < wd; i++)
            {
                intArray[j * wd + i] = (double)doubleArray[i, j, 0];
            }
        }
        return intArray;
    }
}