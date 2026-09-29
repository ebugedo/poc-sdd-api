using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Sectors;

namespace Poc.SDD.Infrastructure.Persistence;

public class ClientSector
{
    public ClientId ClientId { get; set; }
    public SectorId SectorId { get; set; }
    public Client Client { get; set; }
    public Sector Sector { get; set; }
}