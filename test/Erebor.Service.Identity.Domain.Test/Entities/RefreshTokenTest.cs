using System;
using Erebor.Service.Identity.Domain.Entities;
using Xunit;

namespace Erebor.Service.Identity.Domain.Test.Entities
{
    public class RefreshTokenTest
    {
        private RefreshToken refreshToken;
        public RefreshTokenTest()
        {
            refreshToken = RefreshToken.CreateRefreshToken("601fc1e2ef1e3927d002f39b", "32TgMO++lOqsdUsCcWATYBvQ9c9Eqtv5JONMgqOUrcg=",
                DateTime.Now, DateTime.Now.AddMinutes(1), null);
        }
        [Fact]
        public void Should_Have_Create_RefreshToken()
        {
            Assert.NotNull(refreshToken);
        }

        [Fact]
        public void Should_Have_Revoke_Token()
        {
            var currentTokenExpireDate = refreshToken.CreatedAt;
            var revotedTokenDate=refreshToken.RevokeRefreshToken(DateTime.Now).RevokedAt;
            Assert.True(revotedTokenDate > currentTokenExpireDate);
        }

    }
}