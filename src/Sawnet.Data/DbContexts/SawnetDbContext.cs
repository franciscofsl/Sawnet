using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Sawnet.Core.BaseTypes;
using Sawnet.Core.Events;
using Sawnet.Data.Outbox;

namespace Sawnet.Data.DbContexts;

public class SawnetDbContext<TDbContext> : DbContext, IDbContext
    where TDbContext : SawnetDbContext<TDbContext>
{
    [ExcludeFromCodeCoverage]
    public SawnetDbContext()
    {
    }

    public SawnetDbContext(DbContextOptions<TDbContext> options, IDomainEventPublisher domainEventPublisher) :
        base(options)
    {
        DomainEventDomainEventPublisher = domainEventPublisher;
    }

    protected IDomainEventPublisher DomainEventDomainEventPublisher { get; }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    [ExcludeFromCodeCoverage]
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1434;Database=CookBook;User=sa;Password=SqlServer_Docker2023;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}