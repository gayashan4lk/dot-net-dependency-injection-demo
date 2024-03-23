using Microsoft.Extensions.DependencyInjection;

namespace MyAppDI;

public interface IDemoScopedService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
}