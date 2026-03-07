using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class TransientService2 : DisposedService, ITransientService2;

public interface ITransientService2 : IHasInstanceId;
