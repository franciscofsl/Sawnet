using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Application.Cqrs;
using Sawnet.Core.Modules;

namespace Sawnet.Application;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(CqrsModule))]
public abstract class SawnetApplicationModule : SawnetModule
{
    protected virtual IReadOnlyList<Assembly> ValidatorsAssemblies { get; } = Enumerable.Empty<Assembly>().ToList();

    public override void ConfigureCustomServices(IServiceCollection services)
    {
        base.ConfigureCustomServices(services);
        ConfigureValidators(services);
    }

    private void ConfigureValidators(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(ValidatorsAssemblies);
    }
}