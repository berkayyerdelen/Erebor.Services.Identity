using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

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
