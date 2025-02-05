using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class GetConnection : IGetConnection
    {
        public async Task<Observation> Connection(ConfigSerialize config, ILogger logger)
        {
            logger.LogInformation("Обращение к API {time}", DateTime.Now);
            HttpClient httpClient = new HttpClient();
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, config.WeatherAPI.URL + config.WeatherAPI.KEY);
            using HttpResponseMessage response = await httpClient.SendAsync(request);
            Observation restoredObservation = await response.Content.ReadFromJsonAsync<Observation>();
            logger.LogInformation("Возвращение спаршеной строки {time}", DateTime.Now);
            return restoredObservation;
        }
    }
}
