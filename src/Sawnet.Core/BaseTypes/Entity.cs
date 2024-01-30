using Sawnet.Core.GuardClauses;

namespace Sawnet.Core.BaseTypes;

public abstract class Entity<TKey> where TKey : EntityId
{
    public TKey Id { get; }

    protected Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = Ensure.NotNull(id, nameof(id));
    }
}