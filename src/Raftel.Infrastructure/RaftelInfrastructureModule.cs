using Raftel.Shared.Modules;

namespace Raftel.Infrastructure;

[ModulesToInclude(typeof(OutboxModule))]
public class RaftelInfrastructureModule : RaftelModule
{
    
}