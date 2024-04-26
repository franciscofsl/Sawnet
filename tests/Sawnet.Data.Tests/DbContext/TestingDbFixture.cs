using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core;
using Sawnet.Core.Events;
using Sawnet.Data.Tests.Types.DomainEvents;
using Sawnet.Data.Tests.Types.Models;
using Sawnet.Infrastructure;
using Sawnet.Shared.Modules;

namespace Sawnet.Data.Tests.DbContext;

[ModulesToInclude(typeof(DddModule),
    typeof(EfCoreModule),
    typeof(SawnetInfrastructureModule))]
public class TestingDbFixture : SawnetDbFixture<TestingDbContext>
{
    protected override void OnConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IDomainEventHandler<SampleModelCreated>), typeof(SampleModelCreatedHandler));
    }
}