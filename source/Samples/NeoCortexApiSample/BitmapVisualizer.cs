using System;

public static class BitmapVisualizer
{
    public static void VisualizeBitmap(int[] inputBitmap, int[] reconstructedBitmap)
    {
        Console.WriteLine("Input Bitmap:");
        PrintBitmap(inputBitmap);

        Console.WriteLine("\nReconstructed Bitmap:");
        PrintBitmap(reconstructedBitmap);
    }

    private static void PrintBitmap(int[] bitmap)
    {
        const char activeSymbol = 'x'; // Character to represent active (1) bits
        const char inactiveSymbol = '.'; // Character to represent inactive (0) bits

        int width = 20; // Adjust this based on the width of your bitmaps

        for (int i = 0; i < bitmap.Length; i++)
        {
            Console.Write(bitmap[i] == 1 ? activeSymbol : inactiveSymbol);

            if ((i + 1) % width == 0)
            {
                Console.WriteLine();
            }
        }
    }
}
