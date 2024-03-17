using System;
using System.Collections.Generic;
using System.Linq;

public class JaccardIndexCalculator
{
    // Method to calculate the Jaccard index between two SDRs
    public double CalculateJaccardIndex(int[] sdr1, int[] sdr2)
    {
        if (sdr1.Length != sdr2.Length)
        {
            throw new ArgumentException("SDRs must have the same length.");
        }

        // Calculate intersection and union counts
        int intersection = 0;
        int union = 0;

        for (int i = 0; i < sdr1.Length; i++)
        {
            if (sdr1[i] == 1 && sdr2[i] == 1)
            {
                intersection++;
            }

            if (sdr1[i] == 1 || sdr2[i] == 1)
            {
                union++;
            }
        }

        // Calculate Jaccard index
        double jaccardIndex = (double)intersection / union;
        return jaccardIndex;
    }
}