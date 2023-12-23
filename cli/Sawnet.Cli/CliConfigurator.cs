using Microsoft.Extensions.DependencyInjection;
using Sawnet.Cli.CodeGen;
using Spectre.Console.Cli;

namespace Sawnet.Cli;

public static class CliConfigurator
{
    public static ITypeRegistrar BuildTypeRegistrar()
    {
        var services = new ServiceCollection();

        ConfigureOtherServices(services);

        return new TypeRegistrar(services);
    }

    internal static void ConfigureApplication(this IConfigurator configurator)
    {
        configurator.ConfigureCodeGen();
    }

    private static void ConfigureOtherServices(IServiceCollection services)
    {
        services.ConfigureCodeGenServices();
    }
}