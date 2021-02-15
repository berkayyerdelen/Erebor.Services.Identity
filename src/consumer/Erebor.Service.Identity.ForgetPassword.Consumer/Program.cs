using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Erebor.Service.Identity.ForgetPassword.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost", UserName = "admin", Password = "admin"};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "forgetpassword", type: ExchangeType.Fanout);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                        exchange: "forgetpassword",
                        routingKey: "");
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        
                        dynamic data = JObject.Parse(message);
                        var password = data.Password;

                        Console.WriteLine(" [x] {0}", message);
                    };
                    channel.BasicConsume(queue: queueName,
                        autoAck: true,
                        consumer: consumer);

                }
            }
        }
    }
    
}
