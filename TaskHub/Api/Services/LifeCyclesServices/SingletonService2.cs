using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class SingletonService2: DisposedService,  ISingletonService2;

public interface ISingletonService2 : IHasInstanceId;