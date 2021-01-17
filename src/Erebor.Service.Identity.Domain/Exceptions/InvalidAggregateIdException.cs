using System;
using System.Runtime.Serialization;

namespace Erebor.Service.Identity.Domain.Exceptions
{
    [Serializable]
    internal class InvalidAggregateIdException : BusinessException
    {
        
        public InvalidAggregateIdException(string message) : base(message)
        {
        }

    }
}