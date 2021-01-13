using Erebor.Service.Identity.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class RefreshToken:Entity, IAggregateRoot
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
