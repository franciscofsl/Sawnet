using Microsoft.Extensions.DependencyInjection;
using Raftel.Core.Contracts;
using Raftel.Data.Outbox;
using Raftel.Data.Repositories;
using Raftel.Shared.Modules;

namespace Raftel.Data;

public class EfCoreModule : RaftelModule
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