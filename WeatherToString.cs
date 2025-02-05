using DataBaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class WeatherToString():IWeatherToString
    {
        public string WeatherStringToSend(Obss obsEntity)
        {
            string weatherStringToSent = "Время " + obsEntity.DATE + $"Температура {obsEntity.TEMP_C} " + " Состояние "
                                       + obsEntity.CONDITION + " Город " + obsEntity.NAME + " json ответ " + obsEntity.JSONRESPONSE;
            return weatherStringToSent;
        }
    }
}
