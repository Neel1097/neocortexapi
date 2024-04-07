using System;
using System.IO;

/// <summary>
/// Class to set up directory structure for experiments.
/// </summary>
public class ExperimentDirectorySetup
{
    private readonly string experimentName;

    /// <summary>
    /// Constructor for ExperimentDirectorySetup class.
    /// </summary>
    /// <param name="experimentName">Name of the experiment.</param>
    public ExperimentDirectorySetup(string experimentName)
    {
        this.experimentName = experimentName;
    }

    /// <summary>
    /// Sets up experiment directory.
    /// </summary>
    /// <returns>The path of the created directory.</returns>
    public string SetupExperimentDirectory()
    {
        string outFolder = experimentName;
        string outputDirectory = Path.Combine(Environment.CurrentDirectory, outFolder);

        try
        {
            if (Directory.Exists(outputDirectory))
            {
                Directory.Delete(outputDirectory, true);
            }

            Directory.CreateDirectory(outputDirectory);
        }
        catch (Exception ex)
        {
            // Log or handle the exception appropriately
            Console.WriteLine($"Error creating directory: {ex.Message}");
        }

        return outputDirectory;
    }
}
