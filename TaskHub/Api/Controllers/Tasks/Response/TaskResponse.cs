namespace Api.Controllers.Tasks.Response;

public class TaskResponse
{
    public Guid Id { get; }
    public string Title { get; }
    public Guid CreatedByUserId { get; }
    public DateTimeOffset CreatedUtc { get; }

    public TaskResponse(Guid id, string title, Guid userId, DateTimeOffset createdUtc)
    {
        Id = id;
        Title = title;
        CreatedByUserId = userId;
        CreatedUtc = createdUtc;
    }
}