using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Clients.Queries;

public class ListClientsQuery : IRequest<Result>
{
}