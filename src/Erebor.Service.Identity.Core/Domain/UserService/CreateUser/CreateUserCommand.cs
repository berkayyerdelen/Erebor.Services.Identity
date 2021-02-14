using Erebor.Service.Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Erebor.Service.Identity.Core.Domain.UserService.CreateUser
{
    public class CreateUserCommand:IRequest
    {
        public List<Email> Emails { get; set; }
        public List<Role> Roles { get;  set; }
        public string UserName { get; set; }
        public string Password { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public bool IsActive { get;  set; }
    }
}
