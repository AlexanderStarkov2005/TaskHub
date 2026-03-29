using Api.Attributes;
using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

[ApiController]
[Route("tasks")]
[ResponseTimeHeader] 
[StudentInfoHeaders] 
public sealed class TasksController : ControllerBase
{
    private readonly IManageTaskUseCase _taskUseCase;

    public TasksController(IManageTaskUseCase taskUseCase)
    {
        _taskUseCase = taskUseCase;
    }
    
    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTaskAsync(
        [FromBody] CreateTaskRequest? request,
        CancellationToken cancellationToken)
    {
        var task = await _taskUseCase.CreateTaskAsync(request!, cancellationToken);
        
        return Ok(task);
    }
    
    [HttpGet("get-all")]
    public async Task<ActionResult<TaskListResponse>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var response = await _taskUseCase.GetAllTasksAsync(cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{id?}")]
    public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync(
        [FromRouteTaskId] Guid id, 
        CancellationToken cancellationToken)
    {
        var taskResponse = await _taskUseCase.GetTaskByIdAsync(id, cancellationToken);
        
        if (taskResponse is null)
        {
            return NotFound();
        }

        return Ok(taskResponse);
    }
    
    [HttpPut("{id?}/title")]
    public async Task<IActionResult> SetTaskTitleAsync(
        [FromRouteTaskId] Guid id,
        [FromBody] SetTaskTitleRequest? request,
        CancellationToken cancellationToken)
    {
        await _taskUseCase.SetTaskTitleAsync(id, request!.Title!, cancellationToken);
        return NoContent();
    }
    
    [HttpDelete("{id?}")]
    public async Task<IActionResult> DeleteTaskByIdAsync(
        [FromRouteTaskId] Guid id, 
        CancellationToken cancellationToken)
    {
        var deleted = await _taskUseCase.DeleteTaskByIdAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpDelete("delete-all")]
    public async Task<IActionResult> DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _taskUseCase.DeleteAllTasksAsync(cancellationToken);
        return NoContent();
    }
}