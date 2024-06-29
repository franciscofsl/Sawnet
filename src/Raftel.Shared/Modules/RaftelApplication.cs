using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Raftel.Shared.Modules;

public abstract class RaftelApplication
{
    public virtual void ConfigureServices(IServiceCollection services)
    {

    }

    internal virtual void ConfigureModules(IServiceCollection services)
    {
        var modules = GetModules();

        foreach (var module in modules)
        {
            module.ConfigureServices(services);
        }
    }

    private IReadOnlyList<RaftelModule> GetModules()
    {
        var modulesToIncludeAttribute = GetType().GetCustomAttribute<ModulesToIncludeAttribute>();

        return modulesToIncludeAttribute?.Modules ?? Enumerable.Empty<RaftelModule>().ToList();
    }
}
