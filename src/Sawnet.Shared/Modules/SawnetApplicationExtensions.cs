using Microsoft.Extensions.DependencyInjection;

namespace Sawnet.Shared.Modules;

public static class SawnetApplicationExtensions
{
    public static TSawnetApplication AddSawnetApplication<TSawnetApplication>(this IServiceCollection services)
        where TSawnetApplication : SawnetApplication
    {
        var application = Activator.CreateInstance<TSawnetApplication>();

        application.ConfigureServices(services);
        application.ConfigureModules(services);

        return application;
    }
}
