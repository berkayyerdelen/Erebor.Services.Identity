using System.Threading.Tasks;
using Erebor.Service.Identity.Shared.CommonDTO;
using MassTransit;

namespace Erebor.Service.Identity.ForgetPassword.Consumer.Consumers
{
    public class MailSenderConsumer : IConsumer<UserInfoForgetPasswordDto>
    {
        public Task Consume(ConsumeContext<UserInfoForgetPasswordDto> context)
        {
            var t = context.Message.Password;
            var p = context.Message.UserName;
            return Task.CompletedTask;
        }
    }
   
}