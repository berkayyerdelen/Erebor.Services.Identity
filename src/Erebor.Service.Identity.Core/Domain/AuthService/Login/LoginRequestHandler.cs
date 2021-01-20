using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Exceptions;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Shared.Security;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthManager _jwtTokenManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public LoginRequestHandler(IUserRepository userRepository, IJwtAuthManager jwtTokenManager, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _jwtTokenManager = jwtTokenManager;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<LoginResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            //ToDo:Need to check that refresh token expired or not 
            var user = await _userRepository.GetUserByNameAsync(request.UserName);
            var isValidPassword = PasswordHelper.Check(user.Password, request.Password);
            if (!isValidPassword)
                throw new ServiceException("Incorrect Password");
            var roles = user.Roles;
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name,user.UserName)
            };
            roles.ForEach(role => { claims.Add(new Claim(ClaimTypes.Role, role.Value)); });
            var token = await _jwtTokenManager.GenerateTokens(user.UserName, claims, DateTime.Now);
            return new LoginResult()
            {
                Id = user.Id,
                Token = token
            };
        }
    }
}