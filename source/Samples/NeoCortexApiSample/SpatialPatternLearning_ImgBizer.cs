﻿using Accord.Imaging.Filters;
using Daenet.ImageBinarizerLib;
using Daenet.ImageBinarizerLib.Entities;
using LearningFoundation;
using NeoCortex;
using NeoCortexApi;
using NeoCortexApi.Encoders;
using NeoCortexApi.Entities;
using NeoCortexApi.Network;
using NeoCortexApi.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace NeoCortexApiSample
{
    /// <summary>
    /// Implements an experiment that demonstrates how to learn spatial patterns.
    /// SP will learn every presented input in multiple iterations.
    /// </summary>
    public class SpatialPatternLearning_ImgBizer
    {
        public void Run()
        {
            Console.WriteLine($"Hello NeocortexApi! Experiment {nameof(SpatialPatternLearning_ImgBizer)}");

            // Used as a boosting parameters
            // that ensure homeostatic plasticity effect.
            double minOctOverlapCycles = 1.0;
            double maxBoost = 5.0;

            // We will use 200 bits to represent an input vector (pattern).
            int inputBits = 784;

            // We will build a slice of the cortex with the given number of mini-columns
            int numColumns = 1024;


            // This is a set of configuration parameters used in the experiment.
            HtmConfig cfg = new HtmConfig(new int[] { inputBits }, new int[] { numColumns })
            {
                CellsPerColumn = 10,
                MaxBoost = maxBoost,
                DutyCyclePeriod = 100,
                MinPctOverlapDutyCycles = minOctOverlapCycles,

                GlobalInhibition = false,
                NumActiveColumnsPerInhArea = 0.02 * numColumns,
                PotentialRadius = (int)(0.15 * inputBits),
                LocalAreaDensity = -1,
                ActivationThreshold = 10,

                MaxSynapsesPerSegment = (int)(0.01 * numColumns),
                Random = new ThreadSafeRandom(42),
                StimulusThreshold = 10,
            };


           
            int[] inpSdr = ImgBinarizer.Imgo();
            List<double> inputValues = new List<double>();

            BinarySDRConverter converter = new BinarySDRConverter();
            // Call the ConvertToDouble method with your inpSdr array
            double convertedValue = converter.ConvertToDouble(inpSdr);

            // Add the converted value to your list
            inputValues.Add(convertedValue);
            double max =inpSdr.Length;
            Console.WriteLine($"Length of inpSdr - {max}");
           
            Console.WriteLine("\nElements of the array:");
           
            foreach (int num in inpSdr)
            {
                Console.Write(num);
            }



            // This dictionary defines a set of typical encoder parameters.
            Dictionary<string, object> settings = new Dictionary<string, object>()
            {
                { "W", 15},
                { "N", inputBits},
                { "Radius", -1.0},
                { "MinVal", 0.0},
                { "Periodic", false},
                { "Name", "scalar"},
                { "ClipInput", false},
                { "MaxVal", max}
            };


            EncoderBase encoder = new ScalarEncoder(settings);
            var sp = RunExperiment(cfg, encoder, inputValues);

            RunRustructuringExperiment(sp, encoder, inputValues);


            /*  // We create here 100 random input values.
              List<double> inputValues = new List<double>();

              for (int i = 0; i < (int)max; i++)
              {
                  inputValues.Add((double)i);


              }*/
        }


        /// <summary>
        /// Implements the experiment.
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="encoder"></param>
        /// <param name="inputValues"></param>
        /// <returns>The trained bersion of the SP.</returns>
        private static SpatialPooler RunExperiment(HtmConfig cfg, EncoderBase encoder, List<double> inputValues)
        {
            // Creates the htm memory.
            var mem = new Connections(cfg);

            bool isInStableState = false;

            //
            // HPC extends the default Spatial Pooler algorithm.
            // The purpose of HPC is to set the SP in the new-born stage at the begining of the learning process.
            // In this stage the boosting is very active, but the SP behaves instable. After this stage is over
            // (defined by the second argument) the HPC is controlling the learning process of the SP.
            // Once the SDR generated for every input gets stable, the HPC will fire event that notifies your code
            // that SP is stable now.
            HomeostaticPlasticityController hpa = new HomeostaticPlasticityController(mem, inputValues.Count * 1,
                (isStable, numPatterns, actColAvg, seenInputs) =>
                {
                    // Event should only be fired when entering the stable state.
                    // Ideal SP should never enter unstable state after stable state.
                    if (isStable == false)
                    {
                        Debug.WriteLine($"INSTABLE STATE");
                        // This should usually not happen.
                        isInStableState = false;
                    }
                    else
                    {
                        Debug.WriteLine($"STABLE STATE");
                        // Here you can perform any action if required.
                        isInStableState = true;
                    }
                });

            // It creates the instance of Spatial Pooler Multithreaded version.
            SpatialPooler sp = new SpatialPooler(hpa);
            //sp = new SpatialPoolerMT(hpa);

            // Initializes the 
            sp.Init(mem, new DistributedMemory() { ColumnDictionary = new InMemoryDistributedDictionary<int, NeoCortexApi.Entities.Column>(1) });

            // mem.TraceProximalDendritePotential(true);

            // It creates the instance of the neo-cortex layer.
            // Algorithm will be performed inside of that layer.
            CortexLayer<object, object> cortexLayer = new CortexLayer<object, object>("L1");

            // Add encoder as the very first module. This model is connected to the sensory input cells
            // that receive the input. Encoder will receive the input and forward the encoded signal
            // to the next module.
            cortexLayer.HtmModules.Add("encoder", encoder);

            // The next module in the layer is Spatial Pooler. This module will receive the output of the
            // encoder.
            cortexLayer.HtmModules.Add("sp", sp);

            double[] inputs = inputValues.ToArray();

            // Will hold the SDR of every inputs.
            Dictionary<double, int[]> prevActiveCols = new Dictionary<double, int[]>();

            // Will hold the similarity of SDKk and SDRk-1 fro every input.
            Dictionary<double, double> prevSimilarity = new Dictionary<double, double>();

            //
            // Initiaize start similarity to zero.
            foreach (var input in inputs)
            {
                prevSimilarity.Add(input, 0.0);
                prevActiveCols.Add(input, new int[0]);
            }

            // Learning process will take 1000 iterations (cycles)
            int maxSPLearningCycles = 500;

            int numStableCycles = 0;

            for (int cycle = 0; cycle < maxSPLearningCycles; cycle++)
            {
                Debug.WriteLine($"Cycle  ** {cycle} ** Stability: {isInStableState}");


                // This trains the layer on input pattern.
                foreach (var input in inputs)
                {
                    double similarity;

                    // Learn the input pattern.
                    // Output lyrOut is the output of the last module in the layer.
                    var lyrOut = cortexLayer.Compute((object)input, true) as int[];

                    // This is a general way to get the SpatialPooler result from the layer.
                    var activeColumns = cortexLayer.GetResult("sp") as int[];

                    var actCols = activeColumns.OrderBy(c => c).ToArray();

                    similarity = MathHelpers.CalcArraySimilarity(activeColumns, prevActiveCols[input]);

                    Debug.WriteLine($"[cycle={cycle.ToString("D4")}, i={input}, cols=:{actCols.Length} s={similarity}] SDR: {Helpers.StringifyVector(actCols)}");

                    prevActiveCols[input] = activeColumns;
                    prevSimilarity[input] = similarity;
                }

                if (isInStableState)
                {
                    numStableCycles++;
                }

                if (numStableCycles > 5)
                    break;
            }

            return sp;
        }

        private void RunRustructuringExperiment(SpatialPooler sp, EncoderBase encoder, List<double> inputValues)
        {
            //Calling the directory function to create the directory.
            var directorySetup = new ExperimentDirectorySetup(nameof(RunRustructuringExperiment));
            string outFolder = directorySetup.SetupExperimentDirectory();
            // Creating an instance of the jaccardIndex class.
            var jaccardIndexCalculator = new JaccardIndexCalculator(); // New Jaccard index calculator instance
            // Create an instance of BitmapComparator
            var bitmapComparator = new BitmapComparator();

            int[] inpSdr = ImgBinarizer.Imgo();// Directly get binarized values
           
            

            // Generating the bitmap for the produced input SDR.
            string outputPath = Path.Combine(outFolder,"input.png");
           BitmapVisualizer.GenerateAndDrawBitmap(inpSdr, outputPath, text: null);// Calling the BitmapVisualiser fucntion to create the bitmaps.



            Debug.WriteLine(inpSdr);
           var actCols = sp.Compute(inpSdr, false);
           var probabilities = sp.Reconstruct(actCols);
           int inpSdrLength = inpSdr.Length;
     
            int[] reconstructedInput = new int[inpSdrLength];      
            //Apply threshold directly to probabilities to reconstruct input as binary SDR
            foreach (var kvp in probabilities)
            {
                // Check if the probability is greater than or equal to 0.5
                if (kvp.Value >= 8)
                {
                    // Set the corresponding index in the reconstructed input to 1
                    reconstructedInput[kvp.Key] = 1;
                }
            }

            //Printing the Input SDR and the Reconstructed SDR.
            Console.WriteLine($"\nInput SDR: {string.Join(", ", inpSdr)}\n");
            Console.WriteLine($"Reconstructed SDR: {string.Join(", ", reconstructedInput)}");
            // Calculate the Jaccard index
            double jaccardIndex = jaccardIndexCalculator.CalculateJaccardIndex(inpSdr, reconstructedInput);

            // Generate a bitmap to visualize the similarity
            string similarityOutputPath = Path.Combine(outFolder, $"Jaccard_Index ={jaccardIndex*100}.png");
            BitmapVisualizer.GenerateAndDrawBitmap(reconstructedInput, similarityOutputPath, text: $"Jaccard: {jaccardIndex}");
            // Bitmap comparator.
            // Compare the similarity between the two bitmaps
            Bitmap inputBitmap = new Bitmap(outputPath);
            Bitmap reconstructedBitmap = new Bitmap(similarityOutputPath);
            double similarityPercentage = BitmapComparator.Compare(inputBitmap, reconstructedBitmap);
            Console.WriteLine($"Input: Image, Bitmap Similarity Percentage: {similarityPercentage}");
            Console.WriteLine($"Jaccard Index Percentage: {jaccardIndex*100}");


        }
    }
}