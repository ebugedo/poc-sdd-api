namespace Poc.SDD.Domain.Clients;

public class ClientName : ValueObject
{
    public string Value { get; }

    public ClientName(string name)
    {
        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}