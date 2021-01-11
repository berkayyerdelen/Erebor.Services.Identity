using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities.Base
{
    public abstract class AggregateRoot
    {
        private readonly List<INotification> _events = new List<INotification>();
        public IEnumerable<INotification> Events => _events;
        public Entity Id { get; protected set; }
        protected void AddEvent(INotification @event) => _events.Add(@event);
        protected void RemoveEvent(INotification @event) => _events.Remove(@event);

    }
}
