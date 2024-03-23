namespace MyAppDI;

internal sealed class DemoSingletonService : IDemoSingletonService
{
    Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
}