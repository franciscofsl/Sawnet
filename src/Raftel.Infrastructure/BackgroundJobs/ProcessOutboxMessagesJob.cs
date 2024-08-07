﻿using Quartz;
using Raftel.Core.Events;

namespace Raftel.Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ProcessOutboxMessagesJob(IDomainEventPublisher publisher, OutboxMessageStore outboxMessageStore) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var messages = await outboxMessageStore.GetNotProcessedMessagesAsync(context.CancellationToken);

        foreach (var outboxMessage in messages)
        {
            if (outboxMessage.ToDomainEvent() is not { } domainEvent)
            {
                continue;
            }

            await publisher.Publish(domainEvent, context.CancellationToken);

            outboxMessage.ProcessedOn = DateTime.UtcNow;
        }

        await outboxMessageStore.SaveAsync();
    }
}