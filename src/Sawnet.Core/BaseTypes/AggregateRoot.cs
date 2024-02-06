namespace Sawnet.Core.BaseTypes;

public abstract class AggregateRoot<TKey> : WithDomainEvents
    where TKey : EntityId
{
    public TKey Id { get; protected init; }
}