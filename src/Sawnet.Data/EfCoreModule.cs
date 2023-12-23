using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Contracts;
using Sawnet.Core.Modules;
using Sawnet.Data.Repositories;

namespace Sawnet.Data;

public class EfCoreModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
    }
}
