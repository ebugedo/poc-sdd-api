using Poc.SDD.Domain.Sectors;

namespace Poc.SDD.Domain.Clients;

public class Client : AggregateRoot<ClientId>
{
    public ClientName Name { get; private set; }
    public ClientEmail Email { get; private set; }
    public ClientPhone Phone { get; private set; }
    public ISet<SectorId> Sectors { get; private set; } = new HashSet<SectorId>();
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Client() { }

    public Client(ClientId id, ClientName name, ClientEmail email, ClientPhone phone)
        : base(id)
    {
        Name = name;
        Email = email;
        Phone = phone;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(ClientName name, ClientEmail email, ClientPhone phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
        UpdatedAt = DateTime.UtcNow;
    }
}