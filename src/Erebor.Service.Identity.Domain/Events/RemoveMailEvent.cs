using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class RemoveMailEvent : INotification
    {
        public string Email { get; set; }
        public RemoveMailEvent(string email)
        {
            Email = email;
        }
    }
}
