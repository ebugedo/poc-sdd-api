using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Clients.Queries;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Result>
{
    public Task<Result> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        // Validate query
        if (request.Id == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Client ID is required" }));

        // In a real app, would query the repository
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}