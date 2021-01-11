using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class DeActivateUserEvent: INotification
    {
        public DeActivateUserEvent(bool isActive)
        {
            IsActive = isActive;
        }
        public bool IsActive { get; private set; }
    }

}
