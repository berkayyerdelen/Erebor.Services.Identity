using System;
using Erebor.Service.Identity.Domain.Entities.Base;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Login
{
    public class LoginRequest:IRequest<LoginResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public string RefreshToken { get; set; }
    }
}