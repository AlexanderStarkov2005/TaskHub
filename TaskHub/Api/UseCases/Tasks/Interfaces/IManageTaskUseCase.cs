using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;

namespace Api.UseCases.Tasks.Interfaces;

public interface IManageTaskUseCase
{
    public Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request, CancellationToken cancellationToken);
    
    public Task<TaskListResponse> GetAllTasksAsync(CancellationToken cancellationToken);
    
    public Task<TaskResponse?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);
    
    public Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);
    
    public Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);
    
    public Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}