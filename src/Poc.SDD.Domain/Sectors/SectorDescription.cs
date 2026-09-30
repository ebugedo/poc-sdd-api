namespace Poc.SDD.Domain.Sectors;

public class SectorDescription : ValueObject
{
    public string Value { get; }

    public SectorDescription(string description)
    {
        Value = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}