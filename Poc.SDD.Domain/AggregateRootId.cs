using System;

namespace Poc.SDD.Domain;

public abstract class AggregateRootId : IEquatable<AggregateRootId>
{
    public Guid Value { get; protected set; }

    protected AggregateRootId(Guid value)
    {
        Value = value;
    }

    public bool Equals(AggregateRootId? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;
        return Equals((AggregateRootId)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}