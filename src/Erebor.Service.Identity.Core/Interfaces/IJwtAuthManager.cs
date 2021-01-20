using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IJwtAuthManager
    {
        Task<(string,DateTime,string)> GenerateTokens(string username, List<Claim> claims, DateTime date);
        Task<(ClaimsPrincipal, JwtSecurityToken)> DecodeJwtToken(string token);
        Task<(string, DateTime, string )> RefreshToken(string refreshToken, string accessToken, DateTime date);
    }
}