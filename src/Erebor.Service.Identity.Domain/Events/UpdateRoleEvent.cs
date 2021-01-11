using Erebor.Service.Identity.Domain.Entities;
using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class UpdateRoleEvent: INotification
    {
        public Role Roles { get; set; }
        public string Value { get; set; }

        public UpdateRoleEvent(string value, Role roles)
        {
            Value = value;
            Roles = roles;
        }
    }

}
