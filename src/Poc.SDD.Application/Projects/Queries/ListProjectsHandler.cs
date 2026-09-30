using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Projects.Queries;

public class ListProjectsHandler : IRequestHandler<ListProjectsQuery, Result>
{
    public Task<Result> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
    {
        // In a real app, would query the repository to list all projects
        // For now, just return success
        return Task.FromResult(Result.Success());
    }
}