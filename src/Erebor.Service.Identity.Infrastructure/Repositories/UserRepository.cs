using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities.Base;

namespace Erebor.Service.Identity.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContext _applicationContext;

        public UserRepository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task CreateUserAsync(User user)
        {
            await _applicationContext.Users.InsertOneAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _applicationContext.Users.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _applicationContext.Users.FindSync(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _applicationContext.Users.FindSync(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
           return await _applicationContext.Users.FindSync(x => true).ToListAsync();
        }
      
        public async Task UpdateUserAsync(User user)
        {
            await _applicationContext.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }
    }
}
