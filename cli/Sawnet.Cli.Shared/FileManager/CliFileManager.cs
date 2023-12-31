namespace Sawnet.Cli.Shared.FileManager;

public class CliFileManager : ICliFileManager
{
    public async Task<CliFileInfo> SaveAsync(CliFileInfo fileInfo)
    {
        if (!Directory.Exists(fileInfo.Path))
        {
            Directory.CreateDirectory(fileInfo.Path);
        }

        await File.WriteAllTextAsync(fileInfo.FullPath, fileInfo.Content);

        return fileInfo;
    } 
}