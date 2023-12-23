using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Application.Cqrs.Queries;
using Sawnet.Core.Modules;

namespace Sawnet.Application.Cqrs;

[ExcludeFromCodeCoverage]
public class CqrsModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(_ =>
            {
                var name = _.GetName().Name;
                return name != null && name.Contains("Application");
            })
            .ToList();

        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}