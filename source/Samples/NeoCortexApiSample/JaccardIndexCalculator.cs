using System;

/// <summary>
/// Class for calculating Jaccard Index between two Sparse Distributed Representations (SDRs).
/// </summary>
public class JaccardIndexCalculator
{
    /// <summary>
    /// Calculates the Jaccard Index between two SDRs.
    /// </summary>
    /// <param name="sdr1">The first SDR.</param>
    /// <param name="sdr2">The second SDR.</param>
    /// <returns>The Jaccard Index between the two SDRs.</returns>
    /// <exception cref="ArgumentException">Thrown when SDRs have different lengths.</exception>
    public double CalculateJaccardIndex(int[] sdr1, int[] sdr2)
    {
        // Calculate Jaccard Index: Intersection count divided by Union count.
        // Jaccard Index measures similarity between sets by comparing intersection to union.

        // If SDRs have different lengths, throw ArgumentException.
        if (sdr1.Length != sdr2.Length)
        {
            throw new ArgumentException("SDRs must have the same length.");
        }

        // Calculate intersection and union counts
        int intersection = 0;
        int union = 0;

        // Iterate through elements of SDRs
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
