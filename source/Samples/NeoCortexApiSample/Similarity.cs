using System;

class Similarity
{
    public static double CalculateSim(int[] inpSdr, int[] thresholdvalues)
    {
        // Check if arrays have the same length
        if (inpSdr.Length != thresholdvalues.Length)
        {
            throw new ArgumentException("Arrays must have the same length.");
        }

        int matchingCount = 0;
        for (int i = 0; i < inpSdr.Length; i++)
        {
            if (inpSdr[i] == thresholdvalues[i])
            {
                matchingCount++;
            }
        }

        var similarity = (double)matchingCount / inpSdr.Length * 100;
        return similarity;
    }
}