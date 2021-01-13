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
        public IBusinessRule BrokenRule { get; }
        public BusinessException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {

        }
        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
