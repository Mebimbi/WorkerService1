using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System;
using System.Net.Http.Json;
using WorkerService1.Interfaces;
namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Weather _weather;
        public Worker(ILogger<Worker> logger,Weather weather)
        {
            _logger = logger;
            _weather = weather;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        { 
                
                while (!stoppingToken.IsCancellationRequested)
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                    {
                        _weather.WeatherToMail();
                    }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3600000, stoppingToken);
                }
        }
    }
}

