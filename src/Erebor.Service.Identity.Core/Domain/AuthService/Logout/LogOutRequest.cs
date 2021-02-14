using MediatR;

namespace Erebor.Service.Identity.Core.Domain.AuthService.Logout
{
    public class LogOutRequest:IRequest
    {
        public LogOutRequest(string currentUserName)
        {
            CurrentUserName = currentUserName;
        }

        public string CurrentUserName { get; set; }

    }
}