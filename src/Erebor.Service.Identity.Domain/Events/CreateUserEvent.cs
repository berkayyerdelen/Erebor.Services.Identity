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
        public CreateUserEvent(List<Role> roles, List<Email> emails, string password, DateTime createdAt)
        {
            Emails = emails;
            Password = password;
            CreatedAt = createdAt;
        }
        public string Id { get; set; }
        public List<Email> Emails { get; private set; }
        public List<Role> Roles { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }

}
