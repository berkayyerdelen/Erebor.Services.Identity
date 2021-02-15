using Erebor.Service.Identity.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<User> GetUserByEmailAsync(string email);
    }
}
