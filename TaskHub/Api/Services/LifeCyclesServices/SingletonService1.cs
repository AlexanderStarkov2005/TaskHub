using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class SingletonService1 : DisposedService, ISingletonService1;

public interface ISingletonService1 : IHasInstanceId;