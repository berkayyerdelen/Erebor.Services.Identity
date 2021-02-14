using System;

namespace Erebor.Service.Identity.Domain.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }

    }
}
