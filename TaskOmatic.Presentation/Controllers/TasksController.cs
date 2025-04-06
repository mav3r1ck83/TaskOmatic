using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskOmatic.Application.Commands.Tasks.CreateTask;
using TaskOmatic.Application.Commands.Tasks.DeleteTask;
using TaskOmatic.Application.Commands.Tasks.UpdateTask;
using TaskOmatic.Application.Queries.Tasks.GetTask;
using TaskOmatic.Application.Queries.Tasks.GetTaskById;

namespace TaskOmatic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetTasksQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetTaskByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched task ID.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteTaskCommand(id));
        return result ? NoContent() : NotFound();
    }
}