namespace Poc.SDD.Domain.Sectors;

public class SectorName : ValueObject
{
    public string Value { get; }

    public SectorName(string name)
    {
        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}