using System;
using System.Text;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Infrastructure.RabbitMQ.Settings;
using Erebor.Service.Identity.Shared.CommonDTO;
using MassTransit;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Erebor.Service.Identity.Infrastructure.RabbitMQ
{
    public class ForgetPasswordPublisher: IForgetPasswordPublisher
    {
        private readonly IBus _bus;
        public ForgetPasswordPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task ForgetPasswordSender(UserInfoForgetPasswordDto userinfo)
        {
            Uri uri = new Uri("rabbitmq://localhost/mailQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(userinfo);
        }
    }

  

  
}