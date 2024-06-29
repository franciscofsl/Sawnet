using Microsoft.Extensions.DependencyInjection;

namespace Raftel.Shared.Modules;

public abstract class RaftelModule
{
    public virtual void ConfigureCustomServices(IServiceCollection services)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureCustomServices(services);
        var modules = GetModules();

        foreach (var module in modules)
        {
            module.ConfigureServices(services);
        }
    }

    internal IReadOnlyList<RaftelModule> GetModules()
    {
        var type = GetType();

        var modulesToIncludeAttribute = type.GetCustomAttributes(typeof(ModulesToIncludeAttribute), true);

        return modulesToIncludeAttribute
            .Cast<ModulesToIncludeAttribute>()
            .SelectMany(_ => _.Modules)
            .ToList();
    }
}