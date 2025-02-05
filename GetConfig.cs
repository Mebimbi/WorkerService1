using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class GetConfig() : IGetConfig
    {

        public ConfigSerialize Config(ILogger logger)
        {
            logger.LogInformation("Старт получения настроек {time}", DateTime.Now);
            string filepath = @"C:\Users\user\source\repos\WorkerService1\appsettings.Development.json";
            ConfigSerialize config = JsonConvert.DeserializeObject<ConfigSerialize>(File.ReadAllText(filepath));
            logger.LogInformation($"Настройки получены в: {DateTime.Now.ToLongTimeString()}");
            return config;
        }
    }
}
