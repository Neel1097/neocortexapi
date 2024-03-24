
using System;

public class BinarySDRConverter
{
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