using System;

namespace Erebor.Service.Identity.Core.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string empty):base(empty)
        {
            
        }
    }
}