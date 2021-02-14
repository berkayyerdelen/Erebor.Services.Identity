using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IJwtAuthManager
    {
        Task<(string,DateTime,string)> GenerateTokens(string username, List<Role> claims, DateTime date);
        Task RemoveExpiredRefreshTokens();
        Task RemoveRefreshTokenByUserId(string userId);
    }
}