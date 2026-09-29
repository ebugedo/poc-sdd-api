using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors;

public class AssignSectorToProjectHandler : IRequestHandler<AssignSectorToProjectCommand, Result>
{
    public Task<Result> Handle(AssignSectorToProjectCommand request, CancellationToken cancellationToken)
    {
        // Validate command
        if (request.ProjectId == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Project ID is required" }));

        if (request.SectorId == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Sector ID is required" }));

        // In a real app, would use domain service to assign sector to project
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}