using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;

namespace Erebor.Service.Identity.Infrastructure.Hangfire
{
    public class RemoveExpiredTokenManager
    {
        public readonly IJwtAuthManager _jwtAuthManager;
        public RemoveExpiredTokenManager(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        public  void RemoveExpiredTokens()
        { 
            _jwtAuthManager.RemoveExpiredRefreshTokens();
        }
    }

   
}