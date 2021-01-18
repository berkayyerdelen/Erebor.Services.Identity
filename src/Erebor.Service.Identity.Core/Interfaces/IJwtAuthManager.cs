using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IJwtAuthManager
    {
        Task<string> GenerateTokens(string username, List<Claim> claims, DateTime date);
    }
}