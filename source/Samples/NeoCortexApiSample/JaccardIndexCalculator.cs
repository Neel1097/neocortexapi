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
        return;
    }
}