using NeoCortexApi;
using NeoCortexApi.Encoders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NeoCortexApiSample
{
    class Program
    {
        /// <summary>
        /// This sample shows a typical experiment code for SP and TM.
        /// You must start this code in debugger to follow the trace.
        /// and TM.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our project ML 23/24-04");
            Console.WriteLine("Implement the Spatial Pooler SDR Reconstruction");
            Console.WriteLine("Created by:");
            Console.WriteLine("    Subham Singh[1506413]");
            Console.WriteLine("    Amit Maity[1502808]");
            Console.WriteLine("    Ruby Kiran[1504617]\n\n");
            Console.WriteLine("Press 1 to run the experiment with Scalar values using Scalar Encoder");
            Console.WriteLine("Press 2 to run the experiment with a Mnist Image using Image Binarizer ");
            Console.WriteLine("Press any other key to exit");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (key)
            {
                case '1':
                    SpatialPatternLearning experiment = new SpatialPatternLearning();
                    experiment.Run();
                    break;
                case '2':
                    // Starts experiment that demonstrates how to learn spatial patterns.
                    SpatialPatternLearning_ImgBizer experiment_image = new SpatialPatternLearning_ImgBizer();
                    experiment_image.Run();
                    break;
                default:
                    Console.WriteLine("Exiting...");
                    break;
            }
        }
        

     

       
    }
}
