using Sawnet.Cli.CodeGen.Templates;
using Sawnet.Cli.CodeGen.Templates.Aggregate;
using Sawnet.Cli.CodeGen.Templates.Aggregate.ValueObjects;
using Sawnet.Cli.Shared;
using Sawnet.Cli.Shared.FileManager;

namespace Sawnet.Cli.CodeGen.Commands.AddAggregate;

public class AddAggregateCommand : AsyncCommand<AddAggregateSettings>
{
    private readonly ICliFileManager _cliFileManager;

    public AddAggregateCommand(ICliFileManager cliFileManager)
    {
        _cliFileManager = cliFileManager;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, AddAggregateSettings settings)
    {
        var entityInfo = new EntityInfo(settings.PluralName, settings.SingularName);

        await AddCoreTypes(entityInfo);

        return 1;
    }

    private async Task AddCoreTypes(EntityInfo entityInfo)
    {
        await AddAggregate(entityInfo);
        await AddAggregateId(entityInfo);
    }

    private async Task AddAggregate(EntityInfo entityInfo)
    {
        var template = new AggregateTemplate()
        {
            EntityInfo = entityInfo
        };

        var content = template.TransformText();
        var targetPath = $"{ApplicationStructure.Core}\\{entityInfo.PluralName}";

        var fileInfo = new CliFileInfo(entityInfo.SingularName, targetPath, content);

        await _cliFileManager.SaveAsync(fileInfo);
    }

    private async Task AddAggregateId(EntityInfo entityInfo)
    {
        var template = new AggregateIdTemplate()
        {
            EntityInfo = entityInfo
        };

        var content = template.TransformText();
        var targetPath = $"{ApplicationStructure.Core}\\{entityInfo.PluralName}\\ValueObjects";

        var fileInfo = new CliFileInfo(entityInfo.IdType, targetPath, content);

        await _cliFileManager.SaveAsync(fileInfo);
    }
}