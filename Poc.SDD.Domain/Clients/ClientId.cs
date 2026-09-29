namespace Poc.SDD.Domain.Clients;

public class ClientId : AggregateRootId
{
    public ClientId(Guid value) : base(value) { }

    public static ClientId CreateUnique() => new(Guid.NewGuid());
}