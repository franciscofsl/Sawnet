using Microsoft.Extensions.DependencyInjection;

namespace Sawnet.Shared.Modules;

public static class ModulesToIncludeExtensions
{
    public static void ConfigureSafeServices(this ModulesToIncludeAttribute modulesToIncludeAttribute,
        IServiceCollection services)
    {
        if (modulesToIncludeAttribute is null)
        {
            return;
        }

        foreach (var module in modulesToIncludeAttribute.Modules)
        {
            module.ConfigureServices(services);
        }
    }
}