using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mod1;
using Mod1.Shared;
using Mod1.Source;
using Mod1.Target;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<Configuration>();
builder.Services.AddTransient<ProductImporter>();
builder.Services.AddTransient<IProductSource, ProductSource>();
builder.Services.AddTransient<IProductTarget, ProductTarget>();
builder.Services.AddTransient<IProductFormatter, ProductFormatter>();
builder.Services.AddTransient<IPriceParser, PriceParser>();

using IHost host = builder.Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();
productImporter.Run();
