namespace Sawnet.Core.BaseTypes;

public abstract class Entity<TKey> : EntityWithDomainEvents where TKey : EntityId
{
    protected Entity()
    {
    }

    public TKey Id { get; protected init; }
}