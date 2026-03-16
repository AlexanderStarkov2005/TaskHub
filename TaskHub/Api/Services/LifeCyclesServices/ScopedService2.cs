using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class ScopedService2 : DisposedService,   IScopedService2;

public interface IScopedService2 : IHasInstanceId;