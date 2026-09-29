using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Clients;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, Result>
{
    public Task<Result> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        // Validate command
        if (string.IsNullOrWhiteSpace(request.Name))
            return Task.FromResult(Result.Failure(new List<string> { "Name is required" }));

        if (string.IsNullOrWhiteSpace(request.Email))
            return Task.FromResult(Result.Failure(new List<string> { "Email is required" }));

        // In a real app, would use domain repository to persist
        // For now, just validate and return success
        return Task.FromResult(Result.Success());
    }
}