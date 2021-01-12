using Erebor.Service.Identity.Domain.Exceptions;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities.Base
{
    public class Entity
    {
           

        private readonly List<INotification> _events = new List<INotification>();
        public IEnumerable<INotification> Events => _events;     
        protected void AddEvent(INotification @event) => _events.Add(@event);
        protected void RemoveEvent(INotification @event) => _events.Remove(@event);
      
    }
}
