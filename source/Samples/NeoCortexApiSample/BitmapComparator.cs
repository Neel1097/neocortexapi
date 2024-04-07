using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

internal class BitmapComparator
{
    /// <summary>
    /// Compares two bitmaps and calculates the similarity percentage between them.
    /// </summary>
    /// <param name="bmp1">The first bitmap to compare.</param>
    /// <param name="bmp2">The second bitmap to compare.</param>
    /// <returns>The similarity percentage between the two bitmaps.</returns>
    public static double Compare(Bitmap bmp1, Bitmap bmp2)
    {
        // Ensure that the two bitmaps have the same dimensions
        if (bmp1.Width != bmp2.Width || bmp1.Height != bmp2.Height)
        {
            throw new ArgumentException("Bitmaps must have the same dimensions for comparison.");
        }

        int matchingPixels = 0;
        int totalPixels = bmp1.Width * bmp1.Height;

        // Compare corresponding pixels in the two bitmaps
        for (int x = 0; x < bmp1.Width; x++)
        {
            for (int y = 0; y < bmp1.Height; y++)
            {
                Color color1 = bmp1.GetPixel(x, y);
                Color color2 = bmp2.GetPixel(x, y);

                // Check if the colors are identical
                if (color1.ToArgb() == color2.ToArgb())
                {
                    matchingPixels++;
                }
            }
        }
        // Calculate the similarity percentage
        double similarityPercentage = (double)matchingPixels / totalPixels * 100;

        return similarityPercentage;
    }
}
