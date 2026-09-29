using MediatR;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors.Queries;

public class ListSectorsHandler : IRequestHandler<ListSectorsQuery, Result>
{
    public Task<Result> Handle(ListSectorsQuery request, CancellationToken cancellationToken)
    {
        // In a real app, would query the repository to list all sectors
        // For now, just return success
        return Task.FromResult(Result.Success());
    }
}