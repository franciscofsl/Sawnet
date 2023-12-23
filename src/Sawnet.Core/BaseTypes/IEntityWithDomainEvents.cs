using Sawnet.Core.Events;

namespace Sawnet.Core.BaseTypes;

public interface IEntityWithDomainEvents
{
    IReadOnlyList<IDomainEvent> Events { get; }

    void ClearDomainEvents();
}