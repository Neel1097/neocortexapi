using System;
using System.Drawing;
using NeoCortex;
using NeoCortexApi.Utility;

/// <summary>
/// Class for generating and drawing a bitmap based on input data.
/// </summary>
public class BitmapVisualizer
{
    /// <summary>
    /// Generates and draws a bitmap based on the input data.
    /// </summary>
    /// <param name="inputData">The input data as an array of integers.</param>
    /// <param name="outputPath">The file path where the bitmap will be saved.</param>
    /// <param name="text">Optional text to be displayed on the bitmap.</param>
    public static void GenerateAndDrawBitmap(int[] inputData, string outputPath, string text = null)
    {
        int sideLength = (int)Math.Sqrt(inputData.Length);
        int[,] twoDimenArray = ArrayUtils.Make2DArray<int>(inputData, sideLength, sideLength);
        var twoDimArray = ArrayUtils.Transpose(twoDimenArray);

        NeoCortexUtils.DrawBitmap(twoDimArray, 1024, 1024, outputPath, Color.Gray, Color.Green, text: text);
    }
}
