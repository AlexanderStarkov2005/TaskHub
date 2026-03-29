using Dal.Entities;

namespace Dal.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<TaskEntity> CreateAsync(string title, Guid userId, DateTimeOffset createdUtc, CancellationToken ct);
    
    Task<IReadOnlyCollection<TaskEntity>> GetAllAsync(CancellationToken ct);
    
    Task<TaskEntity?> GetByIdAsync(Guid taskId, CancellationToken ct);
    
    Task UpdateTitleAsync(Guid taskId, string title, CancellationToken ct);
    
    Task<bool> DeleteAsync(Guid taskId, CancellationToken ct);
    
    Task DeleteAllAsync(CancellationToken ct);
}