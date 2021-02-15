using System;
using System.Text;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Infrastructure.RabbitMQ.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Erebor.Service.Identity.Infrastructure.RabbitMQ
{
    public class ForgetPasswordPublisher: IForgetPasswordPublisher
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _exchangeName;
        private readonly string _userName;
        private IConnection _connection;

        public ForgetPasswordPublisher(IOptions<RabbitMqConfiguration> options)
        {
            _hostName = options.Value.Hostname;
            _password = options.Value.Password;
            _userName = options.Value.UserName;
            _exchangeName = options.Value.ExchangeName;
        }

        public void ForgetPasswordSender(User user)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName =  _hostName,
                    UserName = _userName,
                    Password = _password,
                    
                };
                using (_connection = factory.CreateConnection())
                {
                    using (var channel = _connection.CreateModel())
                    {
                        channel.ExchangeDeclare(_exchangeName,ExchangeType.Fanout,true,false);

                        var json = JsonConvert.SerializeObject(user);
                        var body = Encoding.UTF8.GetBytes(json);

                        channel.BasicPublish(exchange: _exchangeName, "" , basicProperties: null, body: body);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace);
            }
        }
    }

  
}