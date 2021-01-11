using Erebor.Service.Identity.Domain.Entities;
using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class AddMailEvent : INotification
    {
        public Email email { get; set; }

        public AddMailEvent(Email email)
        {
            this.email = email;
        }
    }

}
