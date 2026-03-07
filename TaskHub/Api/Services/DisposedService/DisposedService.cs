using Api.Services.DisposedService.Interfaces;

namespace Api.Services.DisposedService;

public class DisposedService : IDisposable, IHasInstanceId
{
    private Guid? _instanceId;

    public Guid InstanceId => _disposed? throw new ObjectDisposedException(nameof(DisposedService)) : _instanceId.Value;

    private bool _disposed;

    public DisposedService()
    {
        _instanceId = Guid.NewGuid();
        Console.WriteLine($"{nameof(DisposedService)} {InstanceId}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~DisposedService()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            Console.WriteLine($"{nameof(DisposedService)} {InstanceId}");
        }
        
        
        _instanceId = null;
        _disposed = true;
        
    }
}