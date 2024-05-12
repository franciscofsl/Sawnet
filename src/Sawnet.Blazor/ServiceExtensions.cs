﻿using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sawnet.Blazor.Services;
using Sawnet.Blazor.Services.LocalStorage;
using Sawnet.Blazor.Services.LocalStorage.JsonConverters;
using Sawnet.Blazor.Services.LocalStorage.Serialization;
using Sawnet.Blazor.Services.LocalStorage.StorageOptions;
using Sawnet.Blazor.Toast;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using Refit;

namespace Sawnet.Blazor;

public static class ServiceExtensions
{
    public static void AddSawnetBlazor(this WebAssemblyHostBuilder builder)
    {
        var license = builder.Configuration["SyncfusionLicense"];
        SyncfusionLicenseProvider.RegisterLicense(license);
        builder.Services.AddSyncfusionBlazor();
        builder.Services.AddLocalStorage();

        builder.Services.AddSingleton<ToastNotifier>();
        builder.Services.AddSingleton<ToastService>();

        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(_ =>
            {
                var name = _.GetName().Name;
                return name != null && (name.Contains("Blazor"));
            })
            .ToList();
        ConfigureEventNotifiers(builder, assemblies);
    }

    private static void ConfigureEventNotifiers(WebAssemblyHostBuilder builder, List<Assembly> assemblies)
    {
        builder.Services
            .Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(EventNotifier)))
                .AsSelf()
                .WithTransientLifetime());
    }

    public static void AddRestClient<TService>(this WebAssemblyHostBuilder builder, string uri = null) where TService : class, IRestService
    {
        builder.Services.AddRefitClient<TService>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(uri ?? builder.HostEnvironment.BaseAddress);
        });
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