﻿using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities;

namespace Erebor.Service.Identity.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}