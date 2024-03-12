using System;
using System.IO;

public class ExperimentDirectorySetup
{
    private readonly string experimentName;

    public ExperimentDirectorySetup(string experimentName)
    {
        this.experimentName = experimentName;
    }

    public string SetupExperimentDirectory()
    {
        string outFolder = experimentName;

        if (Directory.Exists(outFolder))
        {
            Directory.Delete(outFolder, true);
        }

        Directory.CreateDirectory(outFolder);

        return outFolder;
    }
}