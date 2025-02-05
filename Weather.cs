using DataBaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class Weather
    {
        private readonly IGetConfig _getConfig;
        private readonly IGetConnection _getConnection;
        private readonly IToEntity _toEntity;
        private readonly IWeatherToString _weatherToString;
        private readonly IEntityToDataBase _entityToDataBase;
        private readonly ISendToMail _sendToMail;
        private readonly ILogger _logger;
        public Weather(IGetConfig getConfig, IGetConnection getConnection, IToEntity toEntity,
                       IWeatherToString weatherToString,IEntityToDataBase entityToDataBase, ISendToMail sendToMail, ILogger logger)
        {
            _getConfig = getConfig;
            _getConnection = getConnection;
            _toEntity = toEntity;
            _weatherToString = weatherToString;
            _entityToDataBase = entityToDataBase;
            _sendToMail = sendToMail;
            _logger = logger;
        }
        public async void WeatherToMail()
        {
            _logger.LogInformation("Начало работы {time}", DateTime.Now);
            ConfigSerialize config = _getConfig.Config(_logger);
            Observation observation = await _getConnection.Connection(config, _logger);
            Obss entityObs = _toEntity.ParsToEntity(observation);
            string weatherMessage = _weatherToString.WeatherStringToSend(entityObs);
            _entityToDataBase.EntityToDataBaseSave(entityObs, config, _logger);
            await _sendToMail.SendWeatherToEmail(weatherMessage, config, _logger);
            _logger.LogInformation("Конец, ожидание следующего цикла {time}", DateTime.Now);
        }
    }
}
