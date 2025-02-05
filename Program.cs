using WorkerService1;
using Microsoft.Extensions.DependencyInjection;
using WorkerService1.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.AddTransient<Weather>();
                services.AddTransient<IGetConfig, GetConfig>();
                services.AddTransient<IGetConnection, GetConnection>();
                services.AddTransient<IToEntity, ToEntity>();
                services.AddTransient<IWeatherToString, WeatherToString>();
                services.AddTransient<IEntityToDataBase, EntityToDataBase>();
                services.AddTransient<ISendToMail, SendToMail>();
                services.AddTransient<ILogger>(s => s.GetService<ILogger<Worker>>());
            })
            .Build();
host.Run();
/*
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

IServiceCollection services = new ServiceCollection();
services.AddTransient<Weather>();
services.AddTransient<IGetConfig, GetConfig>();
services.AddTransient<IGetConnection, GetConnection>();
services.AddTransient<IToEntity, ToEntity>();
services.AddTransient<IServices, Services>();

var host = builder.Build();
host.Run();
*/