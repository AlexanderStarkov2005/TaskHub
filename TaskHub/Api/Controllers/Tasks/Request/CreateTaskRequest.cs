namespace Api.Controllers.Tasks.Request;

public class CreateTaskRequest
{
    public required string Title { get; init; }
    public required Guid UserId { get; init; }
}