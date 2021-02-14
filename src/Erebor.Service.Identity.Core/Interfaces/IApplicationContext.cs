using Erebor.Service.Identity.Domain.Entities;
using MongoDB.Driver;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IApplicationContext
    {
        public IMongoCollection<User> Users { get; }
        public IMongoCollection<RefreshToken> RefreshToken { get;}
    }
}
