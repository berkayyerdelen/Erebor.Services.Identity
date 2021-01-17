using Erebor.Service.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
    }
}
