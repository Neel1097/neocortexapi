using System;
using System.IO;

public class ExperimentDirectorySetup
{
    public string SetupExperimentDirectory(string experimentName)
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