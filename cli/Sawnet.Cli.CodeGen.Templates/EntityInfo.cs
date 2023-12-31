namespace Sawnet.Cli.CodeGen.Templates;

public record EntityInfo(string PluralName, string SingularName)
{
    public string IdType => $"{SingularName}Id"; 
    public string RepoInterfaceType => $"I{PluralName}Repository";
}