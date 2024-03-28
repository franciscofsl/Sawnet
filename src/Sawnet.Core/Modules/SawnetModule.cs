using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sawnet.Core.Modules;

public abstract class SawnetModule
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

    internal IReadOnlyList<SawnetModule> GetModules()
    {
        var type = GetType();
        
        var modulesToIncludeAttribute = type.GetCustomAttributes(typeof(ModulesToIncludeAttribute), true);

        return modulesToIncludeAttribute
            .Cast<ModulesToIncludeAttribute>()
            .SelectMany(_ => _.Modules)
            .ToList();
    }
}