using Erebor.Service.Identity.Shared.Security;
using Xunit;

namespace Erebor.Service.Identity.Domain.Test
{
    public class PasswordHelperTest
    {
        [Fact]
        public void Should_Have_Validate_Password()
        {
            var isValid =
                PasswordHelper.Check("0.1xn2SzCfrWDBjiYriqZbvw==.he0iCQUUszkszYol/5ZYnxOvzdUxgqysdlA49nkwr1Q=",
                    "berkay1");
            Assert.True(isValid);
        }
    }
}