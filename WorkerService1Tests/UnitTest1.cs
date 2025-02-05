using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataBaseConnection;
using WorkerService1;
namespace WorkerService1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var entityObs = new Obss
            {
                DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                TEMP_C = jsonEntity.Current.Temp_c,
                CONDITION = jsonEntity.Current.Condition.Text,
                NAME = jsonEntity?.Location.Name,
                JSONRESPONSE = System.Text.Json.JsonSerializer.Serialize(jsonEntity)
            };
        }
    }
}
