using System.Collections.Generic;

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
