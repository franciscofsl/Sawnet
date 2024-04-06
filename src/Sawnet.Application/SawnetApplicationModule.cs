using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Sawnet.Application.Cqrs;
using Sawnet.Core.Modules;

namespace Sawnet.Application;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(CqrsModule))]
public abstract class SawnetApplicationModule : SawnetModule
{
    protected virtual IReadOnlyList<Assembly> ValidatorsAssemblies { get; } = Enumerable.Empty<Assembly>().ToList();
}