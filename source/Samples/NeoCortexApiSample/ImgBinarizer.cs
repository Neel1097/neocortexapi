using Daenet.ImageBinarizerLib;
using Daenet.ImageBinarizerLib.Entities;

public class ImgBinarizer
{
    public static int[] Imgo()
    {
        var parameters = new BinarizerParams
        {
            InputImagePath = "F:\\YOURDIRR\\Picture\\1144.png",
            ImageHeight = 28,
            ImageWidth = 28,
            
        };
        ImageBinarizer bizer = new ImageBinarizer(parameters);

        var doubleArray = bizer.GetArrayBinary();
        var hg = doubleArray.GetLength(1);
        var wd = doubleArray.GetLength(0);
        var intArray = new int[hg * wd];
        for (int j = 0; j < hg; j++)
        {
            for (int i = 0; i < wd; i++)
            {
                intArray[j * wd + i] = (int)doubleArray[i, j, 0];
            }
        }
        return intArray;
    }
}