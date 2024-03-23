using Microsoft.Extensions.DependencyInjection;

namespace MyAppDI;

public interface IDemoTransientService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
}