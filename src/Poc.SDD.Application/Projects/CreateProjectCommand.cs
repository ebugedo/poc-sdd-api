using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Projects;

public class CreateProjectCommand : IRequest<Result>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ClientId { get; set; }
}