using Dal.Entities;
using Dal.Repositories.Interfaces;
using Logic.Tasks.Models;
using Logic.Tasks.Services.Interfaces;

namespace Logic.Tasks.Services;

internal sealed class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    
    private readonly IUserRepository _userRepository;

    public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }
    
    public async Task<TaskModel> CreateTaskAsync(string title, Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new ArgumentException($"Пользователь с ID {userId} не найден");
        }
        
        var task = await _taskRepository.CreateAsync(title, userId, DateTimeOffset.UtcNow, cancellationToken);
        
        return new TaskModel(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }
    
    public async Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync(cancellationToken);

        return tasks
            .Select(x => new TaskModel(x.Id, x.Title, x.CreatedByUserId, x.CreatedUtc))
            .ToList()
            .AsReadOnly();
    }
    
    public async Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(taskId, cancellationToken);

        if (task == null)
        {
            return null;
        }

        return new TaskModel(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }

    public async Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken)
    {
        await _taskRepository.UpdateTitleAsync(taskId, title, cancellationToken);
    }

    public async Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await _taskRepository.DeleteAsync(taskId, cancellationToken);
    }
    
    public async Task DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteAllAsync(cancellationToken);
    }
}