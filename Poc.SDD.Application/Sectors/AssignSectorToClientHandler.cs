using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors;

public class AssignSectorToClientHandler : IRequestHandler<AssignSectorToClientCommand, Result>
{
    public Task<Result> Handle(AssignSectorToClientCommand request, CancellationToken cancellationToken)
    {
        // Validate command
        if (request.ClientId == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Client ID is required" }));

        if (request.SectorId == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Sector ID is required" }));

        // In a real app, would use domain service to assign sector to client
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}