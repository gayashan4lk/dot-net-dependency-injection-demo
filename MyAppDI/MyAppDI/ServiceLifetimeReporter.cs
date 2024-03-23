namespace MyAppDI;

internal sealed class ServiceLifetimeReporter
{
    private readonly IDemoTransientService _transientService;
    private readonly IDemoScopedService _scopedService;
    private readonly IDemoSingletonService _singletonService;

    public ServiceLifetimeReporter(IDemoTransientService transientService, IDemoScopedService scopedService, IDemoSingletonService singletonService)
    {
        _transientService = transientService;
        _scopedService = scopedService;
        _singletonService = singletonService;
    }

    public void ReportServiceLifetimeDetails(string lifetimeDetails)
    {
        Console.WriteLine(lifetimeDetails);
        
        LogService(_transientService, "Always different");
        LogService(_scopedService, "Changes only with lifetime");
        LogService(_singletonService, "Always the same");
    }

    private static void LogService<T>(T service, string message) where T : IReportServiceLifetime =>
        Console.WriteLine($"{typeof(T).Name}: {service.Id} ({message})");
}