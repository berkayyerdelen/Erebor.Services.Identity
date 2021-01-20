using Erebor.Service.Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erebor.Service.Identity.Domain.Entities.Base;

namespace Erebor.Service.Identity.Core.Domain.UserService.CreateUser
{
    public class CreateUserCommand:IRequest
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<Email> Emails { get; set; }
        public List<Role> Roles { get;  set; }
        public string UserName { get; set; }
        public string Password { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public bool IsActive { get;  set; }
    }
}
