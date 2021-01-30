using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Infrastructure.Context
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly IMongoDatabase _database = null;

        public ApplicationContext(IOptions<DataBaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<User> Users => _database.GetCollection<User>("User");
        public IMongoCollection<RefreshToken> RefreshToken => _database.GetCollection<RefreshToken>("RefreshToken");
        
    }
}
