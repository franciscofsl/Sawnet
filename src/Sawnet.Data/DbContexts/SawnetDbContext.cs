using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Sawnet.Core.BaseTypes;
using Sawnet.Core.Events;

namespace Sawnet.Data.DbContexts;

public class SawnetDbContext<TDbContext> : DbContext, IDbContext
    where TDbContext : SawnetDbContext<TDbContext>
{
    [ExcludeFromCodeCoverage]
    public SawnetDbContext()
    {
    }

    public SawnetDbContext(DbContextOptions<TDbContext> options, IDomainEventPublisher domainEventPublisher) : base(options)
    {
        DomainEventDomainEventPublisher = domainEventPublisher;
    }

    protected IDomainEventPublisher DomainEventDomainEventPublisher { get; }
    
    [ExcludeFromCodeCoverage]
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1434;Database=CookBook;User=sa;Password=SqlServer_Docker2023;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
     
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        await DispatchDomainEvents();
        return result;
    }

    [ExcludeFromCodeCoverage]
    public override int SaveChanges()
    {
        var result = base.SaveChanges();
        DispatchDomainEvents().GetAwaiter().GetResult();
        return result;
    }
    
    private async Task DispatchDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<IEntityWithDomainEvents>()
            .Select(po => po.Entity)
            .Where(po => po.Events.Any())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            foreach (var entityEvents in entity.Events)
            {
                await DomainEventDomainEventPublisher.Publish(entityEvents);
            }

            entity.ClearDomainEvents();
        }
    }
}