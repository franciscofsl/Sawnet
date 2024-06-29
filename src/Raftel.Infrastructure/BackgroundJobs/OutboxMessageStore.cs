using Microsoft.EntityFrameworkCore;
using Raftel.Data;
using Raftel.Data.Outbox;

namespace Raftel.Infrastructure.BackgroundJobs;

public sealed class OutboxMessageStore(IDbContext dbContext)
{
    public const int MaxMessages = 20;

    public async Task<List<OutboxMessage>> GetNotProcessedMessagesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<OutboxMessage>()
            .Where(_ => !_.ProcessedOn.HasValue)
            .Take(MaxMessages)
            .ToListAsync(cancellationToken);
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}