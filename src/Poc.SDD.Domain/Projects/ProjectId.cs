namespace Poc.SDD.Domain.Projects;

public class ProjectId : AggregateRootId
{
    public ProjectId(Guid value) : base(value) { }
}