using MediatR;
using Poc.SDD.Domain.Sectors;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Sectors;

public class CreateSectorCommand : IRequest<Result>
{
    public string Name { get; set; }
    public string Description { get; set; }
}