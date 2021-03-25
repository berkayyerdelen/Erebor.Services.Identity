using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.DTO;
using Erebor.Service.Identity.Core.Exceptions;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Shared.Security;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService
{
    public class LoginRequest : IRequest<LoginResultDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public sealed class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResultDTO>
    {

        private readonly IAuthenticationService _authenticationService;
        public LoginRequestHandler( IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<LoginResultDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authenticationService.Authenticate(request.UserName, request.Password);
      
            return new LoginResultDTO()
            {
                Token = authResult.Token,
                TokenExpireDate = authResult.TokenExpiredDate,
            };
        }
    }
}