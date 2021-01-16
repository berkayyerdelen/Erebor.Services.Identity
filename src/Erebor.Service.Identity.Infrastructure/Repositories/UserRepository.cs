using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContext _applicationContext;

        public UserRepository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task CreateUser(User user)
        {
            await _applicationContext.Users.InsertOneAsync(user);
        }

        public async Task DeleteUser(Guid id)
        {
            await _applicationContext.Users.DeleteOneAsync(x => x.Id.Value == id);
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _applicationContext.Users.FindSync(x => x.Id.Value == id).FirstAsync();
        }

        public async Task<List<User>> GetUsers()
        {
           return await _applicationContext.Users.FindSync(x => true).ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            await _applicationContext.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }
    }
}
