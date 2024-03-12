using System.Collections.Generic;
using System.Linq;

public class PermanenceThreshold
{
    private readonly double[] values;
    private readonly int[] thresholdValues;

    public PermanenceThreshold(IEnumerable<double> inputValues, double threshold)
    {
        values = inputValues.ToArray();
        thresholdValues = CalculateThresholdValues(threshold);
    }

    private int[] CalculateThresholdValues(double threshold)
    {
        int[] result = new int[values.Length];
        int key = 0;

        foreach (var val in values)
        {
            if (val > threshold)
            {
                result[key] = 1;
            }
            else
            {
                result[key] = 0;
            }
            key++;
        }

        return result;
    }

    public int[] GetThresholdValues()
    {
        return thresholdValues;
    }
}
