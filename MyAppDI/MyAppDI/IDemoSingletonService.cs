using Microsoft.Extensions.DependencyInjection;

namespace MyAppDI;

public interface IDemoSingletonService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
}