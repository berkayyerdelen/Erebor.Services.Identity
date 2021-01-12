using Erebor.Service.Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Core.Domain.UserService.CreateUser
{
    public class CreateUserCommand:IRequest
    {
        public string Id { get; set; }
        public List<Email> Emails { get; set; }
        public List<Role> Roles { get;  set; }
        public string Password { get;  set; }
        public DateTime CreatedAt { get;  set; }
        //public bool IsActive { get;  set; }
    }
}
