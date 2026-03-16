using Api.Extensions;
using Api.Services.LifeCyclesServices;
using LoggingLibrary;

namespace Api;

/// <summary>
/// Точка входа приложения
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();
        
        Console.WriteLine("STARTING SCOPE 1\n");
        using (var scope1 = host.Services.CreateScope())
        {
            var sp = scope1.ServiceProvider;
            sp.ResolveAndCompare<ISingletonService1>();
            sp.ResolveAndCompare<IScopedService1>();
            sp.ResolveAndCompare<ITransientService1>();
            sp.ResolveAndCompare<ISingletonService2>();
            sp.ResolveAndCompare<IScopedService2>();
            sp.ResolveAndCompare<ITransientService2>();
        } 

        Console.WriteLine("\nSTARTING SCOPE 2");
        using (var scope2 = host.Services.CreateScope())
        {
            var sp = scope2.ServiceProvider;
            sp.ResolveAndCompare<ISingletonService1>();
            sp.ResolveAndCompare<IScopedService1>();
            sp.ResolveAndCompare<ITransientService1>();
            sp.ResolveAndCompare<ISingletonService2>();
            sp.ResolveAndCompare<IScopedService2>();
            sp.ResolveAndCompare<ITransientService2>();
        }
        Console.WriteLine("\nDISPOSING HOST");
        host.Dispose();

    }
}