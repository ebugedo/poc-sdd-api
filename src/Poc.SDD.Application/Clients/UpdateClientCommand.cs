using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Clients;

public class UpdateClientCommand : IRequest<Result>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}