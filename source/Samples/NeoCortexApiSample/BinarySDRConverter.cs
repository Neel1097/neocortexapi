using System;

/// <summary>
/// Class for converting Binary Sparse Distributed Representation (SDR) to double value.
/// </summary>
public class BinarySDRConverter
{
    /// <summary>
    /// Converts a Binary SDR to its equivalent double value.
    /// </summary>
    /// <param name="binarySDR">The Binary SDR array.</param>
    /// <returns>The double value representing the Binary SDR.</returns>
    public double ConvertToDouble(int[] binarySDR)
    {
        double value = 0;
        for (int i = 0; i < binarySDR.Length; i++)
        {
            // Add the binary value (0 or 1) multiplied by 2 raised to the negative power of the index
            value += binarySDR[i] * Math.Pow(2, -(i + 1));
        }
        return value;
    }
}
