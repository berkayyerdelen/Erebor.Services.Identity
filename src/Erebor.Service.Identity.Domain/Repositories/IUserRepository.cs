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
        Task CreateUser(User user);
    }
}
