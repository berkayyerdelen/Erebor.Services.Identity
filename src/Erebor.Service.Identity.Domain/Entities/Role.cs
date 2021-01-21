using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class Role:ValueObject
    {
        private static List<Role> _roles = new List<Role>() { new Role() { Value = "user" }, new Role() { Value = "admin" }, new Role() { Value = "superadmin" } };

        public Role()
        {

        }
        public string Value { get; set; }
        private static List<Role> Roles => _roles;
        public static bool IsValid(List<Role> roles)
        {
            foreach (var item in roles)
            {
                if (Roles.Any(x => x.Value == item.Value.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsValid(Role role)
        {
            var result = Roles.Any(x => x.Value == role.Value.ToLower());
            return result;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
