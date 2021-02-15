using Erebor.Service.Identity.Domain.Entities;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IForgetPasswordPublisher
    {
        void ForgetPasswordSender(User user);
    }
}