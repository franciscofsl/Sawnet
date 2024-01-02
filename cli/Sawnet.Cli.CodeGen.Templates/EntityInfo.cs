namespace Sawnet.Cli.CodeGen.Templates;

public record EntityInfo(string PluralName, string SingularName)
{
    public string IdType => $"{SingularName}Id"; 
    public string RepoInterfaceType => $"I{PluralName}Repository";
    public string RepoField => $"_{PluralName.ToLower()}Repository";
    public string RepoVariable => $"{PluralName.ToLower()}Repository";
    public string EntityVariable =>SingularName.ToLower();
}