using Sawnet.Cli.CodeGen.Templates;
using Sawnet.Cli.CodeGen.Templates.Aggregate.Application.Commands;
using Sawnet.Cli.CodeGen.Templates.Aggregate.Core;
using Sawnet.Cli.CodeGen.Templates.Aggregate.Core.ValueObjects;
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
        await AddApplicationTypes(entityInfo);

        return 1;
    }

    #region Core Types

    private async Task AddCoreTypes(EntityInfo entityInfo)
    {
        await AddAggregate(entityInfo);
        await AddAggregateId(entityInfo);
        await AddRepositoryInterface(entityInfo);
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

    private async Task AddRepositoryInterface(EntityInfo entityInfo)
    {
        var template = new IAggregateRepositoryTemplate()
        {
            EntityInfo = entityInfo
        };

        var content = template.TransformText();
        var targetPath = $"{ApplicationStructure.Core}\\{entityInfo.PluralName}";

        var fileInfo = new CliFileInfo(entityInfo.RepoInterfaceType, targetPath, content);

        await _cliFileManager.SaveAsync(fileInfo);
    }

    #endregion

    #region Application Types

    private async Task AddApplicationTypes(EntityInfo entityInfo)
    {
        await AddCreateCommand(entityInfo);
        await AddCreateCommandHandler(entityInfo);
    }

    private async Task AddCreateCommand(EntityInfo entityInfo)
    {
        var template = new CreateAggregateCommand()
        {
            EntityInfo = entityInfo
        };

        var content = template.TransformText();
        var targetPath = $"{ApplicationStructure.Application}\\{entityInfo.PluralName}\\Commands\\Create";

        var fileInfo = new CliFileInfo(template.Name, targetPath, content);

        await _cliFileManager.SaveAsync(fileInfo);
    }

    private async Task AddCreateCommandHandler(EntityInfo entityInfo)
    {
        var template = new CreateAggregateCommandHandler()
        {
            EntityInfo = entityInfo
        };

        var content = template.TransformText();
        var targetPath = $"{ApplicationStructure.Application}\\{entityInfo.PluralName}\\Commands\\Create";

        var fileInfo = new CliFileInfo(template.Name, targetPath, content);

        await _cliFileManager.SaveAsync(fileInfo);
    }

    #endregion
}