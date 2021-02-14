using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Logout
{
    public sealed class LogOutRequestHandler : IRequestHandler<LogOutRequest>
    {
        private readonly IJwtAuthManager _jwtAuthManager;

        public LogOutRequestHandler(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        public async Task<Unit> Handle(LogOutRequest request, CancellationToken cancellationToken)
        {
            await _jwtAuthManager.RemoveRefreshTokenByUserId(request.UserId);
            return Unit.Value;
        }
    }
}