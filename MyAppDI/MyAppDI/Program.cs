﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyAppDI;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<IDemoTransientService, DemoTransientService>();
builder.Services.AddScoped<IDemoScopedService, DemoScopedService>();
builder.Services.AddSingleton<IDemoSingletonService, DemoSingletonService>();

builder.Services.AddTransient<ServiceLifetimeReporter>();

using IHost host = builder.Build();

ExemplifyServiceLifetime(host.Services, "Lifetime 1");
ExemplifyServiceLifetime(host.Services, "Lifetime 2");

await host.RunAsync();

static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    
    ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails($"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");
    Console.WriteLine("...");
    
    logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails($"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");
    Console.WriteLine("...");
}
