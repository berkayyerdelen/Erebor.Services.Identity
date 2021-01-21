using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Shared.Security;
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
        public async Task<(string,DateTime,string)> GenerateTokens(string username, List<Claim> claims, DateTime date)
        {
            var jwtToken = new JwtSecurityToken(
                _jwtTokenConfig.Issuer,
               _jwtTokenConfig.Audience,
                claims,
                expires: date.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var refreshToken =  TokenGenerator.GenerateRefreshToken();
            var tokenExpiredDate = date.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration);
            return (accessToken, tokenExpiredDate, refreshToken);
        }

        public async Task<(ClaimsPrincipal, JwtSecurityToken)> DecodeJwtToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new SecurityException("Token can not be null!");
            var principal = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtTokenConfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secret),
                ValidAudience = _jwtTokenConfig.Audience,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(_jwtTokenConfig.AccessTokenExpiration)
            }, out var validatedToken);
            return await Task.FromResult((principal, validatedToken as JwtSecurityToken));
        }
        public async Task<(string, DateTime, string)> RefreshToken(string refreshToken, string accessToken, DateTime date)
        {
            var (principal, jwtToken) = await DecodeJwtToken(accessToken);
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                throw new SecurityTokenException("Invalid Token!");
            var userName = principal?.Identity?.Name;
            return await GenerateTokens(userName, principal?.Claims.ToList(), date);
        }

       

       
    }
}