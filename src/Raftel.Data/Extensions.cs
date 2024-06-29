﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raftel.Data.Outbox;

namespace Raftel.Data;

public static class Extensions
{
    public static void AddRaftelDbContext<TDbContext>(this IServiceCollection services, string connectionString = null)
        where TDbContext : DbContext, IDbContext
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        connectionString ??= configuration?.GetConnectionString("DefaultConnection");

        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddDbContext<IDbContext, TDbContext>(
                (sp, options) => options
                    .UseSqlServer(connectionString)
                    .AddInterceptors(sp.GetRequiredService<ConvertDomainEventsToOutboxMessagesInterceptor>()));
        }
    }
}