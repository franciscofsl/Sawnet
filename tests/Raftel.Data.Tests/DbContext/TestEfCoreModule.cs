using System.Reflection;

namespace Raftel.Data.Tests.DbContext;

public class TestEfCoreModule : EfCoreModule
{
    protected override IReadOnlyList<Assembly> AssembliesToLoadRepositories => new[]
    {
        typeof(TestEfCoreModule).Assembly
    };
}