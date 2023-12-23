namespace Sawnet.Cli.Shared.FileManager;

public interface ICliFileManager
{
    Task<CliFileInfo> SaveAsync(CliFileInfo fileInfo);
 
}