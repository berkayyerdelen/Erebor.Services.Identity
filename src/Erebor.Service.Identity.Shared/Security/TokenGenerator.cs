using System;
using System.Security.Cryptography;

namespace Erebor.Service.Identity.Shared.Security
{
    public class TokenGenerator
    {
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return (Convert.ToBase64String(randomNumber));
        }
    }
}