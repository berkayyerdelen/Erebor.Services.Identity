using System;

namespace Erebor.Service.Identity.Domain.Exceptions
{
    [Serializable]
    internal class InvalidEntityException : BusinessException
    {
        
        public InvalidEntityException(string message) : base(message)
        {
        }
    }
}
