using Api.Services.Disposed;

namespace Api.Extensions;

public static class ServiceProviderExtensions
{
    public static void ResolveAndCompare<TService>(this IServiceProvider provider) 
        where TService : IHasInstanceId
    {
        var first = provider.GetRequiredService<TService>();
        var second = provider.GetRequiredService<TService>();
        
        var serviceName = typeof(TService).Name;
        
        Console.WriteLine($"\nTesting: {serviceName}");
        Console.WriteLine($"First InstanceId:  {first.InstanceId}");
        Console.WriteLine($"Second InstanceId: {second.InstanceId}");
        
        var areSame = ReferenceEquals(first, second);

        Console.WriteLine(areSame ? "Result: Identical objects" : "Result: Different objects ");

        Console.WriteLine();
    }
}