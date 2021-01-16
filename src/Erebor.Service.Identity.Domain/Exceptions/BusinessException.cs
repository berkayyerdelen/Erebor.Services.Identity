using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
