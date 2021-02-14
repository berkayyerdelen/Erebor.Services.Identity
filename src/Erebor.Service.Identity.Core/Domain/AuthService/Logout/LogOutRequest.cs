using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Logout
{
    public class LogOutRequest:IRequest
    {
        public LogOutRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }

    }
}