using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class ScopedService1 : DisposedService,  IScopedService1;

public interface IScopedService1 : IHasInstanceId;