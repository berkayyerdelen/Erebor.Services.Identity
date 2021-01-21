using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.RefreshToken
{
    public class RefreshTokenCommandHandler:IRequestHandler<RefreshTokenCommand,string>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var entity =await _refreshTokenRepository.GetAsync(request.RefreshToken);
            if (entity != null && entity?.RevokedAt > DateTime.Now)
            {
                entity.RevokeRefreshToken();
                entity.Revoke(DateTime.Now.AddMinutes(90));
            }

            await _refreshTokenRepository.UpdateAsync(entity);
            return entity?.Token;
        }
    }
}