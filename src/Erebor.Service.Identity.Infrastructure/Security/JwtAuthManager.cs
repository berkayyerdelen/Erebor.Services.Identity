using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Erebor.Service.Identity.Infrastructure.Security
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly JwtAuthConfig _jwtTokenConfig;
        private readonly byte[] _secret;

        public JwtAuthManager(JwtAuthConfig jwtTokenConfig)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
        }
        public Task<string> GenerateTokens(string username, List<Claim> claims, DateTime date)
        {
            var jwtToken = new JwtSecurityToken(
                _jwtTokenConfig.Issuer,
               _jwtTokenConfig.Audience,
                claims,
                expires: date.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(accessToken);
        }
    }
}