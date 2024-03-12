class Similarity
{
    public static double CalculateSim(int[] inpSdr, int[] thresholdvalues)
    {
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