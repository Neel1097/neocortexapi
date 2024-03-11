using System;


class BitmapSimilarity
{
    static void Main()
    {
        //Calculating the similairity by using the two array

        if (twoDimArray.GetLength(0) != twoDArray.GetLength(0) || twoDimArray.GetLength(1) != twoDArray.GetLength(1))
        {
            throw new ArgumentException("Arrays must have the same dimensions.");
        }
        int totalElements = twoDimArray.GetLength(0) * twoDimArray.GetLength(1);
        int matchingElements = 0;

        for (int i = 0; i < twoDimArray.GetLength(0); i++)
        {
            for (int j = 0; j < twoDimArray.GetLength(1); j++)
            {
                if (twoDimArray[i, j] == twoDArray[i, j])
                {
                    matchingElements++;
                }
            }
        }

        double similarity = matchingElements / totalElements;
        Console.WriteLine(similarity);
    }

}    
}


