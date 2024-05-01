using Sawnet.Shared.Modules;

namespace Sawnet.Infrastructure;

[ModulesToInclude(typeof(OutboxModule))]
public class SawnetInfrastructureModule : SawnetModule
{
    
}