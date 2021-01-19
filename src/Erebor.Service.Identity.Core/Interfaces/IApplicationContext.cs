using Erebor.Service.Identity.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Core.Interfaces
{
    public interface IApplicationContext
    {
        public IMongoCollection<User> Users { get; set; }
        public IMongoCollection<RefreshToken> RefreshToken { get; set; }
    }
}
