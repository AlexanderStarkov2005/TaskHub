using Api.Services.Disposed;

namespace Api.Services.LifeCyclesServices;

public class TransientService1 : DisposedService, ITransientService1;

public interface ITransientService1 : IHasInstanceId;
