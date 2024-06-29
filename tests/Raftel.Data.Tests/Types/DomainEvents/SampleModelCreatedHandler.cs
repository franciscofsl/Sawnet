using Raftel.Core.Contracts;
using Raftel.Core.Events;
using Raftel.Data.Tests.Types.Models;

namespace Raftel.Data.Tests.Types.DomainEvents;

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