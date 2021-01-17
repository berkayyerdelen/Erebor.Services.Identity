using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Exceptions;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Shared.Security;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Login
{
    public class LoginRequestHandler:IRequestHandler<LoginRequest,LoginResult>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoginResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.GetUserAsync(request.UserName);
            var isValidPassword = PasswordHelper.Check(user.Password, request.Password);
            if (!isValidPassword)
                throw new ServiceException("Incorrect Password");
            var roles = user.Roles;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };
            roles.ForEach(role => { claims.Add(new Claim(ClaimTypes.Role, role.Value)); });

            //Todo:Add Token Generetor

            return null;
        }
    }
}