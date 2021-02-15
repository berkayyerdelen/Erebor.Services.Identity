using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;

namespace Erebor.Service.Identity.Core.SelfHosted
{
    public class ScheduledServices
    {
        private readonly IJwtAuthManager _jwtAuthManager;

        public ScheduledServices(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        public void  RemoveRefreshTokens()
        {
             _jwtAuthManager.RemoveExpiredRefreshTokens();
        }
    }
}