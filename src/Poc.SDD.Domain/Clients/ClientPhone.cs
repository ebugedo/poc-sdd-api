namespace Poc.SDD.Domain.Clients;

public class ClientPhone : ValueObject
{
    public string Value { get; }

    public ClientPhone(string phone)
    {
        Value = phone;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}