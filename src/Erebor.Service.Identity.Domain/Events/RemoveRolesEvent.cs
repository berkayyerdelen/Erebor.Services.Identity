using Erebor.Service.Identity.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Erebor.Service.Identity.Domain.Events
{
    public class RemoveRolesEvent: INotification
    {
        public RemoveRolesEvent(List<Role> roles)
        {
            Roles = roles;
        }

        public List<Role> Roles { get; set; }
    }

}
