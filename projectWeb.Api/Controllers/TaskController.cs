using MediatR;
using Microsoft.AspNetCore.Mvc;
using projectWeb.Application.Features.Tareas.Commands.CreateTask;
using projectWeb.Application.Features.Tareas.Queries.GetTasks;

namespace projectWeb.Api.Controllers;


[ApiController]
[Route("api/controller")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        // enviamos el comando al handler a traves de mediatr
        var taskId = await _mediator.Send(command);
        
        
        // retornamos una respuesta con el id de la tarea crada en mysql 
        return Ok(new { id = taskId, message = "Tarea creada exitosamente en la nube " });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // enviamos query 
        var taskss = await _mediator.Send(new GetTasksQuery());
        
        // retornamos respuesta
        return Ok(taskss);
    }
}