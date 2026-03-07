using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class SingletonService2: DisposedService.DisposedService,  ISingletonService2;

public interface ISingletonService2 : IHasInstanceId;