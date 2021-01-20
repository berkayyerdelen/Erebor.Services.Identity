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
                PasswordHelper.Check("0.PS2A7GZ7d4ezu4v3WGkbOw==.ZiV3CIMtNoMTrvU3zIY781XqpCFgTN2pE8zSSL22PAk=",
                    "berkay1");
            Assert.True(isValid);
        }
    }
}