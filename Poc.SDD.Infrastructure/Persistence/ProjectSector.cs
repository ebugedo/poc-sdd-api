using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Sectors;

namespace Poc.SDD.Infrastructure.Persistence;

public class ProjectSector
{
    public ProjectId ProjectId { get; set; }
    public SectorId SectorId { get; set; }
    public Project Project { get; set; }
    public Sector Sector { get; set; }
}