using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Projects.Queries;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, Result>
{
    public Task<Result> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        // Validate query
        if (request.Id == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Project ID is required" }));

        // In a real app, would query the repository
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}