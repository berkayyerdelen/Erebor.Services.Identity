using System;
using System.Runtime.Serialization;

namespace Erebor.Service.Identity.Domain.Entities.Base
{
    [Serializable]
    internal class InvalidAggregateIdException : Exception
    {
        public InvalidAggregateIdException()
        {
        }

        public InvalidAggregateIdException(string message) : base(message)
        {
        }

        public InvalidAggregateIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAggregateIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}