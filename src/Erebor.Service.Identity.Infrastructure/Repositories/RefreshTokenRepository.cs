using System;
using System.Collections.Generic;
using System.Linq;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MongoDB.Driver;

using System.Threading.Tasks;

namespace Erebor.Service.Identity.Infrastructure.Repositories
{
    public class RefreshTokenRepository: IRefreshTokenRepository
    {
        private readonly IApplicationContext _applicationContext;
        public RefreshTokenRepository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<RefreshToken> GetAsync(string token) => await _applicationContext.RefreshToken.FindSync(x => x.Token == token).FirstOrDefaultAsync();

        public async Task AddAsync(RefreshToken token)
        {
            await _applicationContext.RefreshToken.InsertOneAsync(token);
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            await _applicationContext.RefreshToken.ReplaceOneAsync(x => x.Id == token.Id, token);
        }

        public async Task DeleteRefreshToken(string userId)
        {
           await _applicationContext.RefreshToken.DeleteOneAsync(x => x.UserId == userId);
        }
        public async Task DeleteRefreshTokenById(string id)
        {
            await _applicationContext.RefreshToken.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<string>> GetExpiredRefreshTokens()
        {
          var ids = await  _applicationContext.RefreshToken.FindSync(x => x.ExpiredAt < DateTime.Now).ToListAsync();
          return ids.Select(x => x.Id).ToList();
        }
    }
}