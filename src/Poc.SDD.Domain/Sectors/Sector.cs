using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Projects;

namespace Poc.SDD.Domain.Sectors;

public class Sector : AggregateRoot<SectorId>
{
    public SectorName Name { get; private set; }
    public SectorDescription Description { get; private set; }
    public ISet<ClientId> Clients { get; private set; } = new HashSet<ClientId>();
    public ISet<ProjectId> Projects { get; private set; } = new HashSet<ProjectId>();
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Sector() { }

    public Sector(SectorId id, SectorName name, SectorDescription description)
        : base(id)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddClient(ClientId clientId)
    {
        Clients.Add(clientId);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveClient(ClientId clientId)
    {
        Clients.Remove(clientId);
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddProject(ProjectId projectId)
    {
        Projects.Add(projectId);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveProject(ProjectId projectId)
    {
        Projects.Remove(projectId);
        UpdatedAt = DateTime.UtcNow;
    }
}