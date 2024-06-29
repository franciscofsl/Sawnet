using Microsoft.Extensions.DependencyInjection;

namespace Raftel.Shared.Modules;

public static class RaftelApplicationExtensions
{
    public static TRaftelApplication AddRaftelApplication<TRaftelApplication>(this IServiceCollection services)
        where TRaftelApplication : RaftelApplication
    {
        var application = Activator.CreateInstance<TRaftelApplication>();

        application.ConfigureServices(services);
        application.ConfigureModules(services);

        return application;
    }
}
