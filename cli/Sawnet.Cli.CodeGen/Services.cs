using Microsoft.Extensions.DependencyInjection;
using Sawnet.Cli.Shared;
using Sawnet.Cli.Shared.FileManager;

namespace Sawnet.Cli.CodeGen;

public static class Services
{
    public static void ConfigureCodeGenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICliFileManager, CliFileManager>();
    }
}