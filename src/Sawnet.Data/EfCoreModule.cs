using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Contracts;
using Sawnet.Data.Outbox;
using Sawnet.Data.Repositories;
using Sawnet.Shared.Modules;

namespace Sawnet.Data;

public class EfCoreModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();

        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(_ =>
            {
                var name = _.GetName().Name;
                return name != null && (name.Contains(".Core") || name.Contains(".Data"));
            })
            .ToList();
        
        services.Scan(scan => scan 
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IRepository<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }
}