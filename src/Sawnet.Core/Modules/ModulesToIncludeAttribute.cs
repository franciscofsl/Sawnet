namespace Sawnet.Core.Modules;

[AttributeUsage(AttributeTargets.Class)]
public class ModulesToIncludeAttribute : Attribute
{
    private readonly List<SawnetModule> _modules = new List<SawnetModule>();

    public ModulesToIncludeAttribute(params Type[] modulesTypes)
    {
        if (modulesTypes is null || !modulesTypes.Any())
            throw new InvalidOperationException("No module has been configured in the \"ModulesToInclude\" attribute");

        foreach (var moduleType in modulesTypes)
        {
            var moduleInstance = Activator.CreateInstance(moduleType) as SawnetModule;
            _modules.Add(moduleInstance);
        }
    }

    public IReadOnlyList<SawnetModule> Modules => _modules.AsReadOnly();
}