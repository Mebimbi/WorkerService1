using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class ConfigSerialize
    {
        public Mail Mail { get; set; }
        public WeatherAPI WeatherAPI { get; set; }
        public PSQL PSQL { get; set; }
        public ConfigSerialize(Mail mail, WeatherAPI weatherAPI, PSQL pSQL)
        {
            Mail = mail;
            WeatherAPI = weatherAPI;
            PSQL = pSQL;
        }
    }
    public class Mail
    {
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string Password { get; set; }
        public string SMPT { get; set; }
        public Boolean SSL { get; set; }
        public int Port { get; set; }
        public Mail(string mailFrom, string mailTo, string password, string smpt, Boolean ssl, int port)
        {
            MailFrom = mailFrom;
            MailTo = mailTo;
            Password = password;
            SMPT = smpt;
            SSL = ssl;
            Port = port;
        }
    }
    public class WeatherAPI
    {
        public string URL { get; set; }
        public string KEY { get; set; }
        public WeatherAPI(string url, string key)
        {
            URL = url;
            KEY = key;
        }
    }
    public class PSQL
    {
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? Database { get; set; }
        public string? Username { get; set; }
        public string? PasswordSQL { get; set; }
        public PSQL(string host, string port, string database, string username, string passwordsql)
        {
            Host = host;
            Port = port;
            Database = database;
            Username = username;
            PasswordSQL = passwordsql;
        }

    }
}
