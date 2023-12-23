using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sawnet.Core.Modules;

public abstract class SawnetApplication
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

    private IReadOnlyList<SawnetModule> GetModules()
    {
        var modulesToIncludeAttribute = GetType().GetCustomAttribute<ModulesToIncludeAttribute>();

        return modulesToIncludeAttribute?.Modules ?? Enumerable.Empty<SawnetModule>().ToList();
    }
}
