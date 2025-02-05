using MimeKit;
using Newtonsoft.Json;
using MailKit.Net.Smtp;
using System.Net.Http.Json;
using DataBaseConnection;
using Npgsql;
using WorkerService1.Interfaces;

namespace WorkerService1
{
    public class SendToMail : ISendToMail
    {
        public async Task SendWeatherToEmail(string message, ConfigSerialize config, ILogger logger)
        {
            logger.LogInformation("Старт отправки сообщения на почту {time}", DateTime.Now);
            using var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Информация о погоде", config.Mail.MailFrom));
            emailMessage.To.Add(new MailboxAddress("", config.Mail.MailTo));
            emailMessage.Subject = "Погода";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(config.Mail.SMPT, config.Mail.Port, config.Mail.SSL);
                await client.AuthenticateAsync(config.Mail.MailFrom, config.Mail.Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            logger.LogInformation("Соббщение отправлено {time}", DateTime.Now);
        }
    }
}  


