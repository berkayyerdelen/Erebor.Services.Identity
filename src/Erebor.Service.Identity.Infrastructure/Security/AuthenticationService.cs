using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.DTO;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Shared.Helper;
using Erebor.Service.Identity.Infrastructure.Excetptions;
using Erebor.Service.Identity.Shared.Security;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Erebor.Service.Identity.Infrastructure.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtAuthConfig _config;
        public AuthenticationService(IUserRepository userRepository, JwtAuthConfig config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<JwtAuthResultDTO> Authenticate(string UserNameOrEmail, string password)
        {
            User user;
            var isEmail = UserNameOrEmail.IsEmail();
            if (isEmail)
                user = await _userRepository.GetUserByEmailAsync(UserNameOrEmail);
            else
                user = await _userRepository.GetUserByNameAsync(UserNameOrEmail);

            if (user is null)
                throw new NotFoundException("User is empty");

            if (password != PasswordHelper.Decrypt(user.Password))
                throw new InfrastructureException("Password is wrong");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Secret);

            var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };

            user.Roles.ForEach(role => { claimList.Add(new Claim(ClaimTypes.Role, role.Value)); });

            var jwtToken = new JwtSecurityToken(
                _config.Issuer,
               _config.Audience,
                claimList,
                expires: DateTime.UtcNow.AddMinutes(_config.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
            return new JwtAuthResultDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),            
                TokenExpiredDate = DateTime.UtcNow.AddMinutes(_config.AccessTokenExpiration)
            };

        }

        public Task<string> Refresh(string token, IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}