using MediatR;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors;

public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, Result>
{
    public Task<Result> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Task.FromResult(Result.Failure(new List<string> { "Name is required" }));

        if (string.IsNullOrWhiteSpace(request.Description))
            return Task.FromResult(Result.Failure(new List<string> { "Description is required" }));

        return Task.FromResult(Result.Success());
    }
}