using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Raftel.Core.Tests")]

namespace Raftel.Shared.Modules;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ModulesToIncludeAttribute : Attribute
{
    private readonly List<RaftelModule> _modules = new List<RaftelModule>();

    public ModulesToIncludeAttribute(params Type[] modulesTypes)
    {
        if (modulesTypes is null || !modulesTypes.Any())
            throw new InvalidOperationException("No module has been configured in the \"ModulesToInclude\" attribute");

        foreach (var moduleType in modulesTypes)
        {
            var moduleInstance = Activator.CreateInstance(moduleType) as RaftelModule;
            _modules.Add(moduleInstance);
        }
    }

    public IReadOnlyList<RaftelModule> Modules => _modules.AsReadOnly();
}