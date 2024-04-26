using Sawnet.Core.Contracts;
using Sawnet.Core.Events;
using Sawnet.Data.Tests.Types.Models;

namespace Sawnet.Data.Tests.Types.DomainEvents;

public class SampleModelCreatedHandler(IRepository<SampleAggregate, SampleId> repository)
    : IDomainEventHandler<SampleModelCreated>
{ 
    public async Task Handle(SampleModelCreated domainEvent, CancellationToken token = default)
    {
        var aggregate = await repository.GetAsync((SampleId)domainEvent.Id);

        aggregate.Processed = true;

        await repository.UpdateAsync(aggregate);
    }
}