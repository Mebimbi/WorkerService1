using DataBaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class ToEntity() : IToEntity
    {
        public Obss ParsToEntity(Observation jsonEntity)
        {
            var entityObs = new Obss
            {
                DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                TEMP_C = jsonEntity.Current.Temp_c,
                CONDITION = jsonEntity.Current.Condition.Text,
                NAME = jsonEntity?.Location.Name,
                JSONRESPONSE = System.Text.Json.JsonSerializer.Serialize(jsonEntity)
            };
            return entityObs;
        }
    }
}
