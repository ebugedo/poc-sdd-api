using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Sectors;

namespace Poc.SDD.Domain.Projects;

public class Project : AggregateRoot<ProjectId>
{
    public ProjectName Name { get; private set; }
    public ProjectDescription Description { get; private set; }
    public ClientId ClientId { get; private set; }
    public Client Client { get; private set; }
    public ISet<SectorId> Sectors { get; private set; } = new HashSet<SectorId>();
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Project() { }

    public Project(ProjectId id, ProjectName name, ProjectDescription description, ClientId clientId)
        : base(id)
    {
        Name = name;
        Description = description;
        ClientId = clientId;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(ProjectName name, ProjectDescription description)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}