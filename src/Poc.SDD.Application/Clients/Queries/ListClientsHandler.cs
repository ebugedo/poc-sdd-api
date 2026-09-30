using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Clients.Queries;

public class ListClientsHandler : IRequestHandler<ListClientsQuery, Result>
{
    public Task<Result> Handle(ListClientsQuery request, CancellationToken cancellationToken)
    {
        // In a real app, would query the repository to list all clients
        // For now, just return success
        return Task.FromResult(Result.Success());
    }
}