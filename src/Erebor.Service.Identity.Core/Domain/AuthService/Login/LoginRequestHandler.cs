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
        public LoginRequestHandler(IUserRepository userRepository, IJwtAuthManager jwtTokenManager)
        {
            _userRepository = userRepository;
            _jwtTokenManager = jwtTokenManager;
        }
        public async Task<LoginResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserName);
            var isValidPassword = PasswordHelper.Check(user.Password, request.Password);
            if (!isValidPassword)
                throw new ServiceException("Incorrect Password");
            var roles = user.Roles;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
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