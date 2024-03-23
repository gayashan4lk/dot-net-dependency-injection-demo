namespace MyAppDI;

internal sealed class DemoScopedService : IDemoScopedService
{ 
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
}