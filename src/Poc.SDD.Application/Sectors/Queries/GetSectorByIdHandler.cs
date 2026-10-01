using MediatR;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors.Queries;

public class GetSectorByIdHandler : IRequestHandler<GetSectorByIdQuery, Result>
{
    public Task<Result> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            return Task.FromResult(Result.Failure(new List<string> { "Sector ID is required" }));

        return Task.FromResult(Result.Success());
    }
}