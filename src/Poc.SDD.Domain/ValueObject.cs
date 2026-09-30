using System.Collections.Generic;

namespace Poc.SDD.Domain;

public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    protected static bool NotEqualOperator(ValueObject? a, ValueObject? b)
    {
        return !EqualOperator(a, b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((ac, x) => ac ^ x);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();
}