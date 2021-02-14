using MediatR;

namespace Erebor.Service.Identity.Core.Domain.UserService.DeleteUser
{
    public class DeleteUserCommand: IRequest
    {
        public string UserId { get; set; }
    }
}