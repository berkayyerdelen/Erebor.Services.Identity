using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class UpdatePasswordEvent:INotification
    {
        public string Password { get; set; }
        public UpdatePasswordEvent(string password)
        {
            Password = password;
        }
    }
}
