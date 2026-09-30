using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.SDD.Application.Projects.Queries;

namespace Poc.SDD.Api.Controllers.V1;

[ApiController]
[Route("api/v1/proyectos")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> ListAll(CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new ListProjectsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetProjectByIdQuery { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Poc.SDD.Application.Projects.CreateProjectCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] Poc.SDD.Application.Projects.UpdateProjectCommand command, CancellationToken cancellationToken = default)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch");

        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}