using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Sawnet.Blazor;

public static class ServiceExtensions
{
    public static IServiceCollection AddSawnetBlazor(this IServiceCollection services, IConfiguration configuration)
    {
        var license = configuration["SyncfusionLicense"];
        SyncfusionLicenseProvider.RegisterLicense(license);
        services.AddSyncfusionBlazor();

        return services;
    }
}