using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.RefreshToken
{
    public class RefreshTokenCommandHandler:IRequestHandler<RefreshTokenCommand,string>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthManager _jwtAuthManager;
        public RefreshTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var entity =await _refreshTokenRepository.GetAsync(request.Token);
            if (entity != null && entity?.RevokedAt < DateTime.Now)
            {
                entity.RevokeRefreshToken(DateTime.Now);
                
            }
            await _refreshTokenRepository.UpdateAsync(entity);
            var user =await _userRepository.GetUserByIdAsync(entity?.UserId);
            var token =await _jwtAuthManager.GenerateTokens(user.UserName, user.Roles, DateTime.Now);
            return token.Item1;
        }
    }
}