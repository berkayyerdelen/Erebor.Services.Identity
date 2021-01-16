using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class Email:ValueObject
    {
        public string Value { get; set; }
        public Email(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
