using MediatR;
using Poc.SDD.Domain.Projects;
using Poc.SDD.Domain.Shared;

namespace Poc.SDD.Application.Projects.Queries;

public class ListProjectsQuery : IRequest<Result>
{
}