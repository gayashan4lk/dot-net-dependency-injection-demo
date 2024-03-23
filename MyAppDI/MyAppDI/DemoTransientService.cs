namespace MyAppDI;

internal sealed class DemoTransientService : IDemoTransientService
{
    Guid IReportServiceLifetime.Id { get;  } = Guid.NewGuid();
}