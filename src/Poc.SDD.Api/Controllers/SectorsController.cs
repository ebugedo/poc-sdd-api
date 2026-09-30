using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.SDD.Domain.Shared;
using Poc.SDD.Application.Sectors.Queries;

namespace Poc.SDD.Api.Controllers.V1;

[ApiController]
[Route("api/v1/sectores")]
public class SectorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SectorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> ListAll(CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new ListSectorsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = Result.Success();
        return Ok(result);
    }

    [HttpPost("assign-client")]
    public async Task<ActionResult> AssignToClient([FromBody] Poc.SDD.Application.Sectors.AssignSectorToClientCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("assign-project")]
    public async Task<ActionResult> AssignToProject([FromBody] Poc.SDD.Application.Sectors.AssignSectorToProjectCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}