﻿using Raftel.Core.GuardClauses;

namespace Raftel.Core.BaseTypes;

public abstract class Entity<TKey> : WithDomainEvents where TKey : EntityId
{
    public TKey Id { get; protected init; }

    protected Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = Ensure.NotNull(id, nameof(id));
    }
}