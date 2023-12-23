namespace Sawnet.Cli.CodeGen.Commands.AddAggregate;

public class AddAggregateSettings : CodeGenSettings
{
    [Description("Plural name of the entity. Example: Animals")]
    [CommandArgument(0, "[plural-name]")]
    public string PluralName { get; set; }

    [Description("Singular name of the entity. Example: Animal")]
    [CommandArgument(1, "[singular-name]")]
    public string SingularName { get; set; }
    
    [CommandOption("--audited")]
    [DefaultValue(true)]
    public bool? Audited { get; set; }
}