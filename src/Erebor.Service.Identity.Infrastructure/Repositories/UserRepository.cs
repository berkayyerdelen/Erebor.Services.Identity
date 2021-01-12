using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Repositories;
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
    }
}
