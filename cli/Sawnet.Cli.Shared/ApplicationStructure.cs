namespace Sawnet.Cli.Shared;

public static class ApplicationStructure
{
    public static string Core { get; }
    public static string AppName { get; }

    static ApplicationStructure()
    {
        var currentPath = Directory.GetCurrentDirectory();
        AppName = new DirectoryInfo(currentPath).Name;

        var currentPathDirectories = Directory.GetDirectories(currentPath);
        var srcDirectory = currentPathDirectories.First(_ => _.EndsWith("src"));
        var srcDirectories = Directory.GetDirectories(srcDirectory);

        Core = srcDirectories.First(_ => _.EndsWith(nameof(Core)));
    }
}