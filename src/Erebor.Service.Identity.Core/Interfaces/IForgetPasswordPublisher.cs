using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Shared.CommonDTO;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IForgetPasswordPublisher
    {
        Task ForgetPasswordSender(UserInfoForgetPasswordDto userinfo);
    }
}