using Microsoft.Extensions.DependencyInjection;
using Raftel.Shared.Modules;

namespace Raftel.Testing;

public abstract class TestBase<TRaftelApplication> where TRaftelApplication : RaftelApplication
{
    protected TestBase()
    {
        var services = new ServiceCollection();
        Application = services.AddRaftelApplication<TRaftelApplication>();
        ServiceProvider = services.BuildServiceProvider();
    }

    protected TRaftelApplication Application { get; }

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