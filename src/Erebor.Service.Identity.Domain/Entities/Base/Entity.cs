using Erebor.Service.Identity.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities.Base
{
    public class Entity : IEquatable<Entity>
    {
        public Guid Value { get; }
        protected Entity()
        {
            Value = Guid.NewGuid();
        }
        protected Entity(Guid value)
        {
            if (value == Guid.Empty)
                throw new InvalidEntityException("Value can not be Empty");
            Value = value;
        }
        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator Guid(Entity id)
            => id.Value;

        public static implicit operator Entity(Guid id)
            => new Entity(id);

        public override string ToString() => Value.ToString();
    }
}
