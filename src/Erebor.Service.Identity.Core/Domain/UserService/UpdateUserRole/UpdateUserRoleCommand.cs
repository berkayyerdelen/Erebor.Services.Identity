using System;
using System.Collections.Generic;
using Erebor.Service.Identity.Domain.Entities;
using Erebor.Service.Identity.Domain.Entities.Base;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService.UpdateUserRole
{
    public class UpdateUserRoleCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Role CurrentRole { get; set; }
        public string Role { get; set; }
    }
}