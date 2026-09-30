using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors;

public class AssignSectorToProjectCommand : IRequest<Result>
{
    public Guid ProjectId { get; set; }
    public Guid SectorId { get; set; }
}