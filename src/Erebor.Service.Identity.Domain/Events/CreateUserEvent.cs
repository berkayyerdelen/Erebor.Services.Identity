using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Entities.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Events
{
    public class CreateUserEvent : INotification
    {
        public CreateUserEvent(List<Role> roles, List<Email> emails,string userName, string password, DateTime createdAt, bool isActive)
        {
            Roles = roles;
            UserName = userName;
            IsActive = isActive;
            Emails = emails;
            Password = password;
            CreatedAt = createdAt;
        }
        public bool IsActive { get; set; }
        public List<Email> Emails { get;  set; }
        public string UserName { get; set; }
        public List<Role> Roles { get;  set; }
        public string Password { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }

}
