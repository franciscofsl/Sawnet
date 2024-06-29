using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Raftel.Application.Cqrs;
using Raftel.Shared.Modules;

namespace Raftel.Application;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(CqrsModule))]
public abstract class RaftelApplicationModule : RaftelModule
{
}