﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sawnet.Blazor.Forms.Services;
using Sawnet.Blazor.Services.LocalStorage;
using Sawnet.Blazor.Services.LocalStorage.JsonConverters;
using Sawnet.Blazor.Services.LocalStorage.Serialization;
using Sawnet.Blazor.Services.LocalStorage.StorageOptions;
using Sawnet.Blazor.Toast;
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
        services.AddLocalStorage();
        
        services.AddSingleton<ToastNotifier>();
        services.AddSingleton<ToastService>();
        services.AddSingleton<AdvancedModalFormPropertyChangedNotifier>();

        return services;
    }

    private static void AddLocalStorage(this IServiceCollection services)
    {
        services.AddScoped<IJsonSerializer, SystemTextJsonSerializer>();
        services.AddScoped<IStorageProvider, BrowserStorageProvider>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();
        services.AddScoped<ISyncLocalStorageService, LocalStorageService>();

        if (services.All(_ => _.ServiceType != typeof(IConfigureOptions<LocalStorageOptions>)))
        {
            services.Configure<LocalStorageOptions>(_ =>
            {
                _.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                _.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                _.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                _.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                _.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                _.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                _.JsonSerializerOptions.WriteIndented = false;

                _.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
            });
        }
    }
}