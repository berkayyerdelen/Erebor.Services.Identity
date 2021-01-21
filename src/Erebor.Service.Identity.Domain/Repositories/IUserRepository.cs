using Erebor.Service.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities.Base;

namespace Erebor.Service.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByNameAsync(string userName);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(string id);
    }
}
