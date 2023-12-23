using Sawnet.Cli.CodeGen.Commands;
using Sawnet.Cli.CodeGen.Commands.AddAggregate;

namespace Sawnet.Cli.CodeGen;

public static class BranchConfigurator
{
    public static void ConfigureCodeGen(this IConfigurator configurator)
    {
        configurator.AddBranch<CodeGenSettings>("add", _ =>
        {
            _.AddCommand<AddAggregateCommand>("aggregate")
                .WithDescription("Allows the creation of an aggregate.")
                .WithExample("add", "aggregate", "Cars", "Car");
        });
    }
}