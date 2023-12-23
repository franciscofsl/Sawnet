using Sawnet.Core.Events;

namespace Sawnet.Data.Tests.Models;

public record SampleModelCreated(SampleAggregate Model) : IDomainEvent;