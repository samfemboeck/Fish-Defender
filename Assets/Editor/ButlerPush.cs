using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.Diagnostics;
using System.IO;

public class BuildGame : MonoBehaviour
{
    /// <summary>
    /// Builds all versions and pushes them to itch.io.
    /// </summary>
    [MenuItem("Build/Butler Push")]
    public static void ButlerPush()
    {
        string[] butlerArguments = new string[6];

        butlerArguments[0] = "ramo-teamhellep";     // Account
        butlerArguments[1] = "test-01";             // Project

        butlerArguments[3] = "Release";             // Configuration
        butlerArguments[4] = @".\";                 // Solution directory

        if (Build("Windows", BuildTarget.StandaloneWindows, butlerArguments[1], ".exe", butlerArguments[3]))
        {
            butlerArguments[2] = "fd-windows-test";
            butlerArguments[5] = @"bin\Windows\Release\";
            StartButler(butlerArguments);
        }
        if (Build("Linux", BuildTarget.StandaloneLinux64, butlerArguments[1], "", butlerArguments[3]))
        {
            butlerArguments[2] = "fd-linux-test";
            butlerArguments[5] = @"bin\Linux\Release\";
            StartButler(butlerArguments);
        }
        if (Build("OSX", BuildTarget.StandaloneOSX, butlerArguments[1], ".app", butlerArguments[3]))
        {
            butlerArguments[2] = "fd-osx-test";
            butlerArguments[5] = @"bin\OSX\Release\";
            StartButler(butlerArguments);
        }
    }


    #region Targets
    [MenuItem("Build/Local Windows")]
    public static void BuildWindows()
    {
        Build("Windows", BuildTarget.StandaloneWindows, "windowsBuild", ".exe", "Local");
    }

    [MenuItem("Build/Local Linux")]
    public static void BuildLinux()
    {
        Build("Linux", BuildTarget.StandaloneLinux64, "linuxBuild", "", "Local");
    }

    [MenuItem("Build/Local OSX")]
    public static void BuildOSX()
    {
        Build("IOS", BuildTarget.StandaloneOSX, "osxBuild", ".app", "Local");
    }
    #endregion

    #region Build
    /// <summary>
    /// Builds a player targeting the given system.
    /// </summary>
    /// <param name="targetName">Name of the target folder.</param>
    /// <param name="targetOS">Targeted system.</param>
    /// <returns></returns>
    private static bool Build(string folderName, BuildTarget targetOS, string executableName, string suffix, string configurationName)
    {
        string path = $"bin/{folderName}/";
        string pathConfig = path + configurationName;
        string pathExecutable = pathConfig + "/" + executableName + suffix;
        
        string pathBackup = path + "Backup";

        if (Directory.Exists(pathConfig))
        {
            if (configurationName == "Release")
            {
                if (Directory.Exists(pathBackup))
                    Directory.Delete(pathBackup, true);
                Directory.Move(pathConfig, pathBackup);
            }
            else
            {
                Directory.Delete(pathConfig, true);
            }
        }

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scene/Leveldesign.unity" };
        buildPlayerOptions.locationPathName = pathExecutable;
        buildPlayerOptions.target = targetOS;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            UnityEngine.Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            return true;
        }
        else if (summary.result == BuildResult.Failed)
        {
            UnityEngine.Debug.Log("Build failed");
        }
        return false;
    }
    #endregion

    #region Utility
    private static void StartButler(string[] butlerArguments)
    {
        Process butler = new Process();
        butler.StartInfo.FileName = "ButlerPush.bat";
        butler.StartInfo.Arguments = CreateArguments(butlerArguments);
        butler.Start();
    }

    private static string CreateArguments(string[] arguments)
    {
        if (arguments.Length < 1) return null;
        string output = "";
        foreach (string arg in arguments)
        {
            output = output +  arg + " ";
        }
        return output;
    }
    #endregion
}
