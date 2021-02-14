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
        [BsonId] public string Id { get; set; } = Guid.NewGuid().ToString();
        private List<INotification> _events;
        public IReadOnlyCollection<INotification> Events => _events?.AsReadOnly();
        protected void AddEvent(INotification @event)
        {
            _events ??= new List<INotification>();
            _events.Add(@event);
        }

        protected void RemoveEvent(INotification @event) => _events.Remove(@event);
      
    }
}
