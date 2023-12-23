using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core;
using Sawnet.Core.Modules;
using Sawnet.Data.Tests.Models;

namespace Sawnet.Data.Tests.DbContext;

[ModulesToInclude(typeof(DddModule),
    typeof(EfCoreModule))]
public class TestingDbFixture : SawnetDbFixture<TestingDbContext>
{
    protected override void OnConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<IDbContext, TestingDbContext>();
    }
}