using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class ActivateUserEvent : INotification
    {
        public bool IsActive { get; set; }
        public ActivateUserEvent(bool isActive)
        {
            IsActive = isActive;
        }
    }

}
