using System;

namespace Erebor.Service.Identity.Infrastructure.Security
{
    public class JwtAuthResult
    {
        public string Token { get; set; }
        public DateTime TokenExpiredDate { get; set; }
        public string RefreshToken { get; set; }

    }
}