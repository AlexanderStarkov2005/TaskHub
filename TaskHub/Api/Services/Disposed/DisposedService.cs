using Api.Services.Disposed;

namespace Api.Services.DisposedService;

public class DisposedService : IDisposable, IHasInstanceId
{
    public Guid InstanceId { get; } = Guid.NewGuid();

    private bool _disposed;

    public DisposedService()
    {
        Console.WriteLine($"Create {GetType().Name} {InstanceId}");
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        Console.WriteLine($"Dispose {GetType().Name} {InstanceId}");
        
        _disposed = true;
        GC.SuppressFinalize(this);
    }
    
    ~DisposedService()
    {
        Dispose();
    }
}