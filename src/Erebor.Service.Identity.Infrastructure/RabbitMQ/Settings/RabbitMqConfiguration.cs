namespace Erebor.Service.Identity.Infrastructure.RabbitMQ.Settings
{
    public class RabbitMqConfiguration
    {
        public string Hostname { get; set; }

        public string ExchangeName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}