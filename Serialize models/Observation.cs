using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Observation
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Observation(Location location, Current current)
        {
            Location = location;
            Current = current;
        }
    }
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Tz_id { get; set; }
        public int Localtime_epoch { get; set; }
        public string Localtime { get; set; }
        public Location(string name, string region, string country, double lat, double lon, string tz_id, int localtime_epoch, string localtime)
        {
            Name = name;
            Region = region;
            Country = country;
            Lat = lat;
            Lon = lon;
            Tz_id = tz_id;
            Localtime_epoch = localtime_epoch;
            Localtime = localtime;
        }
    }
    public class Current
    {
        public double Temp_c { get; set; }
        public Condition Condition { get; set; }
        public Current(double temp_c, Condition condition)
        {
            Temp_c = temp_c;
            Condition = condition;
        }
    }
    public class Condition
    {
        public string Text { get; set; }
        public Condition(string text)
        {
            Text = text;
        }

    }
}