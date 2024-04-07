
using Daenet.ImageBinarizerLib;
using Daenet.ImageBinarizerLib.Entities;

/// <summary>
/// Provides methods to binarize an image.
/// </summary>
public class ImgBinarizer
{
    /// <summary>
    /// Binarizes an image and returns the binarized image as a 1D array of integers.
    /// </summary>
    /// <returns>The binarized image as a 1D array of integers.</returns>
    public static int[] Imgo()
    {
        // Define parameters for binarization.
        var parameters = new BinarizerParams
        {
            InputImagePath = "C:\\Users\\ACER\\OneDrive\\Desktop\\1.jpg",
            ImageHeight = 28,
            ImageWidth = 28,
        };

        // Create an instance of ImageBinarizer.
        ImageBinarizer bizer = new ImageBinarizer(parameters);

        // Get the binary representation of the image.
        var doubleArray = bizer.GetArrayBinary();

        // Get the height and width of the binary array.
        var hg = doubleArray.GetLength(1);
        var wd = doubleArray.GetLength(0);

        // Initialize a 1D array to store the binarized image.
        var intArray = new int[hg * wd];

        // Convert the 3D doubleArray to a 1D intArray.
        for (int j = 0; j < hg; j++)
        {
            for (int i = 0; i < wd; i++)
            {
                intArray[j * wd + i] = (int)doubleArray[i, j, 0];
            }
        }

        // Return the binarized image as a 1D array of integers.
        return intArray;
    }
}