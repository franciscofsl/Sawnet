using Microsoft.Extensions.DependencyInjection;
using Sawnet.Shared.Modules;

namespace Sawnet.Testing;

public abstract class TestBase<TSawnetApplication> where TSawnetApplication : SawnetApplication
{
    protected TestBase()
    {
        var services = new ServiceCollection();
        Application = services.AddSawnetApplication<TSawnetApplication>();
        ServiceProvider = services.BuildServiceProvider();
    }

    protected TSawnetApplication Application { get; }

    protected IServiceProvider ServiceProvider { get; }

    protected T GetService<T>()
    {
        return ServiceProvider.GetService<T>();
    }

    protected T GetRequiredService<T>()
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}