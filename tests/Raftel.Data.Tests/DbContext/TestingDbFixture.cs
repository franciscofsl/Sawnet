using Microsoft.Extensions.DependencyInjection;
using Raftel.Core;
using Raftel.Core.Events;
using Raftel.Data.Tests.Types.DomainEvents;
using Raftel.Data.Tests.Types.Models;
using Raftel.Infrastructure;
using Raftel.Shared.Modules;

namespace Raftel.Data.Tests.DbContext;

[ModulesToInclude(typeof(DddModule),
    typeof(EfCoreModule),
    typeof(RaftelInfrastructureModule))]
public class TestingDbFixture : RaftelDbFixture<TestingDbContext>
{
    protected override void OnConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IDomainEventHandler<SampleModelCreated>), typeof(SampleModelCreatedHandler));
    }
}