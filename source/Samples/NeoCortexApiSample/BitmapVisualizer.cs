using System;
using System.Drawing;
using NeoCortex;
using NeoCortexApi.Utility;

public class BitmapVisualizer
{
    public static void GenerateAndDrawBitmap(int[] inputData, string outputPath, string text = null)
    {
        int sideLength = (int)Math.Sqrt(inputData.Length);
        int[,] twoDimenArray = ArrayUtils.Make2DArray<int>(inputData, sideLength, sideLength);
        var twoDimArray = ArrayUtils.Transpose(twoDimenArray);

        NeoCortexUtils.DrawBitmap(twoDimArray, 1024, 1024, outputPath, Color.Gray, Color.Green, text: text);
    }
}