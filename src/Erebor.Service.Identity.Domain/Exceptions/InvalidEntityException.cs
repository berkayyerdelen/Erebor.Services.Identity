using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Exceptions
{
    [Serializable]
    internal class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message)
        {
        }
    }
}
