using Raftel.Core.Events;

namespace Raftel.Data.Tests.Types.Models;

public record SampleModelCreated : IDomainEvent
{
    public Guid Id { get; set; }
}