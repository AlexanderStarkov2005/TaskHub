using Dal.Entities;
using Logic.Tasks.Models;

namespace Logic.Tasks.Services.Interfaces;

public interface ITaskService
{
    public Task<TaskModel> CreateTaskAsync(string title, Guid userId, CancellationToken cancellationToken);
    
    public Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken);
    
    public Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);
    
    public Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);
    
    public Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);
    
    public Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}