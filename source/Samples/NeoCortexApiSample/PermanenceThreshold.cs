using System.Collections.Generic;
using System.Linq;

public class PermanenceThreshold
{
    public static double ApplyThreshold(double permanence)
    {
        const double threshold = 0.6;

        // Apply threshold logic
        return permanence < threshold ? 0.0 : 1.0;
    }
    public static Dictionary<int, double> ApplyThreshold(Dictionary<int, double> permanences)
    {
        // Apply threshold logic to each value in the dictionary

        Dictionary<int, double>.ValueCollection values = probabilities.Values;

        return int[] thresholdvalues = new int[inpSdr.Length];


    }
}