namespace Poc.SDD.Domain.Clients;

public class ClientEmail : ValueObject
{
    public string Value { get; }

    public ClientEmail(string email)
    {
        Value = email;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}