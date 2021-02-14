using System.Collections.Generic;
using Erebor.Service.Identity.Domain.Entities;
using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService.GetUsers
{
    public class GetUsersRequest:IRequest<List<User>>
    {
        
    }
}