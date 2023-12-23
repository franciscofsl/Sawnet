using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;
using Sawnet.Data.DbContexts;

namespace Sawnet.Data.Tests;

public abstract class SawnetDbFixture<TDbContext> : IDisposable
    where TDbContext : SawnetDbContext<TDbContext>
{
    private readonly IServiceProvider _serviceProvider;
    private bool _disposed;

    public SawnetDbFixture()
    {
        _serviceProvider = BuildServiceProvider();
        MigrateDbContext();
    }

    public TService GetRequiredService<TService>()
    {
        return _serviceProvider.GetRequiredService<TService>();
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            var dbContext = _serviceProvider.GetRequiredService<TDbContext>();
            dbContext.Database.EnsureDeleted();
        }

        _disposed = true;
    }

    protected virtual void OnConfigureServices(IServiceCollection services)
    {
        
    }
    
    private void MigrateDbContext()
    {
        var dbContext = _serviceProvider.GetRequiredService<TDbContext>();
        dbContext.Database.Migrate();
    }

    private IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        var modulesToIncludeAttribute = GetType().GetCustomAttribute<ModulesToIncludeAttribute>();
        modulesToIncludeAttribute.ConfigureSafeServices(services);

        OnConfigureServices(services);
        ConfigureDbContext(services);
        
        return services.BuildServiceProvider();
    }

    private static void ConfigureDbContext(IServiceCollection services)
    {
        var descriptor = services
            .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TDbContext>));

        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        var dbName = $"TestingDatabase-{Guid.NewGuid()}";
        var connectionString =
            $"Server=localhost,1433;Database={dbName};User=sa;Password=SqlServer_Docker2023;MultipleActiveResultSets=true;TrustServerCertificate=True;";
        services.AddDbContext<IDbContext, TDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}