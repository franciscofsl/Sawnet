using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Sawnet.Application.Cqrs;
using Sawnet.Shared.Modules;

namespace Sawnet.Application;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(CqrsModule))]
public abstract class SawnetApplicationModule : SawnetModule
{
}