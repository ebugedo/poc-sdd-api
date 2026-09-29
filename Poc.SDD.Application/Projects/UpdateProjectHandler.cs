using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Projects;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Result>
{
    public Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        // Validate command
        if (request.Id == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Project ID is required" }));

        if (string.IsNullOrWhiteSpace(request.Name))
            return Task.FromResult(Result.Failure(new List<string> { "Project name is required" }));

        // In a real app, would use domain repository to update
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}