using System;
using System.IO;
using NeoCortex;
namespace Image_Binarizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "";
            string outputPath = ""; // Specify your desired output path
            int threshold = 130; // Set the binarization threshold

            NeoCortexUtils.BinarizeImage(imagePath, outputPath, threshold, "");

            string textFilePath = "F:\txt"; // Path to the text file
            int[] binaryArray = ReadBinaryDataFromFile(textFilePath);

            // Process the binary array as needed
            // ...

            // Example: Print the binary values
            foreach (int value in binaryArray)
            {
                Console.Write(value + " ");
            }
        }

        static int[] ReadBinaryDataFromFile(string filePath)
        {
            string content = File.ReadAllText(filePath);
            int[] binaryArray = new int[content.Length];

            for (int i = 0; i < content.Length; i++)
            {
                if (int.TryParse(content[i].ToString(), out int digit))
                {
                    binaryArray[i] = digit;
                }
                else
                {
                    // Handle parsing failure, e.g., set a default value
                    binaryArray[i] = -1;
                }
            }

            return binaryArray;
        }
    }
}