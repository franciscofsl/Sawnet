using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace Sawnet.Blazor;

public static class ServiceExtensions
{
    public static IServiceCollection AddSawnetBlazor(this IServiceCollection services)
    {
        services.AddRadzenComponents();
        services.AddScoped<DialogService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<TooltipService>();
        services.AddScoped<ContextMenuService>();

        return services;
    }
}