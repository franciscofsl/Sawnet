using Sawnet.Core.Events;

namespace Sawnet.Data.Tests.Types.Models;

public record SampleModelCreated : IDomainEvent
{
    public Guid Id { get; set; }
}