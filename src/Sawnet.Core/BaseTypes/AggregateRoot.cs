namespace Sawnet.Core.BaseTypes;

public abstract class AggregateRoot<TKey> : EntityWithDomainEvents
    where TKey : EntityId
{
    public TKey Id { get; protected init; }
}