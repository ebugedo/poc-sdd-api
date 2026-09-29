using MediatR;
using Poc.SDD.Domain.Clients;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors;

public class AssignSectorToClientCommand : IRequest<Result>
{
    public Guid ClientId { get; set; }
    public Guid SectorId { get; set; }
}