using System;

namespace Poc.SDD.Domain;

public abstract class AggregateRoot<TId> where TId : AggregateRootId
{
    public TId Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    protected AggregateRoot() { }

    protected AggregateRoot(TId id)
    {
        Id = id;
    }
}