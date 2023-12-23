namespace Sawnet.Cli.Shared.FileManager;

public record CliFileInfo(string Name, string Path, string Content, string Extension = "cs")
{
    public string FullPath => $"{Path}\\{Name}.{Extension}";
}