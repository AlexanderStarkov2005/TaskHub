using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

internal sealed class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }
    
    public async Task<TaskEntity> CreateAsync(
        string title, 
        Guid userId, 
        DateTimeOffset createdUtc, 
        CancellationToken ct)
    {
        var entity = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            CreatedByUserId = userId,
            CreatedUtc = createdUtc
        };

        await _context.Tasks.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);

        return entity;
    }
    
    public async Task<IReadOnlyCollection<TaskEntity>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Tasks
            .AsNoTracking()
            .ToListAsync(ct);
    }
    
    public async Task<TaskEntity?> GetByIdAsync(Guid taskId, CancellationToken ct)
    {
        return await _context.Tasks
            .FirstOrDefaultAsync(x => x.Id == taskId, ct);
    }
    
    public async Task UpdateTitleAsync(Guid taskId, string title, CancellationToken ct)
    {
        var entity = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskId, ct);
        
        if (entity != null)
        {
            entity.Title = title;
            await _context.SaveChangesAsync(ct);
        }
    }
    
    public async Task<bool> DeleteAsync(Guid taskId, CancellationToken ct)
    {
        var entity = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskId, ct);
        
        if (entity == null)
        {
            return false;
        }

        _context.Tasks.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
    
    public async Task DeleteAllAsync(CancellationToken ct)
    {
        await _context.Tasks.ExecuteDeleteAsync(ct);
    }
}