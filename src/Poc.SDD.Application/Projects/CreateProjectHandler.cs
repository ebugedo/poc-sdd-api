using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Projects;

public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Result>
{
    public Task<Result> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        // Validate command
        if (string.IsNullOrWhiteSpace(request.Name))
            return Task.FromResult(Result.Failure(new List<string> { "Project name is required" }));

        if (request.ClientId == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Client ID is required" }));

        // In a real app, would use domain repository to persist
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}