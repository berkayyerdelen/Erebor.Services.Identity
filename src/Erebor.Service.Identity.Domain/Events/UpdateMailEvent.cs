using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class UpdateMailEvent : INotification
    {
        public string Email { get; set; }

        public UpdateMailEvent(string email, string value = null)
        {
            Email = email;
            Value = value;
        }

        public string Value { get; set; }
    }

}
