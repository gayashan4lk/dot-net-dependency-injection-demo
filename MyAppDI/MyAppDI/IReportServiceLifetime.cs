using Microsoft.Extensions.DependencyInjection;

namespace MyAppDI;

public interface IReportServiceLifetime
{
    public Guid Id { get;}

    public ServiceLifetime Lifetime { get;}
}